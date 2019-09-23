using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum EnemyState
    {
        PATROL,
        CHASE,
        STAKE,
        STUN
    };

    [SerializeField] NavMeshAgent enemy;
    [SerializeField] int patrol_pattern = 0;
    private EnemyState state;
    private float chase_speed = 10.0f;
    private float chase_thr = 0.6f;
    private Vector3 pos = Vector3.zero;

    private List<Vector3[]> route = new List<Vector3[]>();
    private int now_index = 0;

    private Vector3 light_pos = Vector3.zero;

    private Camera cam;

    public EnemyState enemy_state
    {
        set { state = value; }
        get { return this.state; }
    }

    public float speed
    {
        set { chase_speed = value;  }
        get { return chase_speed; }
    }

    public Vector3 position
    {
        set { pos = value; }
        get { return pos; }
    }

    public Vector3 light_position
    {
        set { light_pos = value; }
    }

    private void Awake()
    {
        cam = Camera.main;
    }

    // Use this for initialization
    void Start()
	{
        InitRoute();
        enemy = gameObject.GetComponent<NavMeshAgent>();
        enemy.destination = Vector3.zero;

	}
	
	// Update is called once per frame
	void Update()
	{
        switch (state)
        {
            case EnemyState.PATROL:
                Patrol();
                break;
            case EnemyState.CHASE:
                Chase();
                break;
            case EnemyState.STAKE:
                Stake();
                break;
            case EnemyState.STUN:
                Stun();
                break;
            default:
                break;
        }
        pos = transform.position;
        Debug.Log(state);
	}

    private void InitRoute()
    {
        route.Add(new Vector3[4] { new Vector3(40f,0f,40f), new Vector3(40f, 0f, -40f), new Vector3(-40f, 0f, -40f), new Vector3(-40f, 0f, 40f) });
        route.Add(new Vector3[4] { new Vector3(20f, 0f, 20f), new Vector3(20f, 0f, -20f), new Vector3(-20f, 0f, -20f), new Vector3(-20f, 0f, 20f) });
    }

    private void Chase()
    {
        if ((transform.position - light_pos).magnitude > 0.6f) {
            enemy.speed = chase_speed;
            enemy.destination = light_pos;
        }
        else
        {
            if(state != EnemyState.STAKE) state = EnemyState.PATROL;
        }
    }
    private void Patrol()
    {
        if ((transform.position-route[patrol_pattern][now_index]).magnitude < 6f) {
            enemy.speed = chase_speed;
            now_index = (now_index+1)%route[patrol_pattern].Length;
            enemy.destination = route[patrol_pattern][now_index];
        }
        enemy.destination = route[patrol_pattern][now_index];
    }

    private void Stake()
    {
        enemy.speed = chase_speed;
        enemy.destination = cam.transform.position;
    }

    private void Stun()
    {

    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "MainCamera")
        {
            state = EnemyState.STAKE;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(state == EnemyState.STAKE)
        {
            state = EnemyState.PATROL;
        }
    }
}