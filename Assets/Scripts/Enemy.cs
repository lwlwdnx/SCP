using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum EnemyState
    {
        PATROL,
        CHASE
    };

    [SerializeField] NavMeshAgent enemy;
    private EnemyState state;
    private float chase_speed = 10.0f;
    private float chase_thr = 0.6f;
    private Vector3 pos = Vector3.zero;

    private List<Vector3[]> route = new List<Vector3[]>();
    private int route_index = 0, now_index = 0;

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

	// Use this for initialization
	void Start()
	{
        InitRoute();
        enemy = gameObject.GetComponent<NavMeshAgent>();
        enemy.destination = Vector3.zero;
        cam = Camera.main;
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
            default:
                break;
        }

        pos = transform.position;
	}

    private void InitRoute()
    {
        route.Add(new Vector3[4] { new Vector3(40f,0f,40f), new Vector3(40f, 0f, -40f), new Vector3(-40f, 0f, -40f), new Vector3(-40f, 0f, 40f) });
    }

    private void Chase()
    {
       enemy.speed = chase_speed;
       enemy.destination = cam.transform.position;
    }
    private void Patrol()
    {
        if ((transform.position-route[route_index][now_index]).magnitude < 6f) {
            enemy.speed = chase_speed;
            now_index = (now_index+1)%route[route_index].Length;
            enemy.destination = route[route_index][now_index];
            Debug.Log(enemy.destination);
        }
        enemy.destination = route[route_index][now_index];
    }
}
