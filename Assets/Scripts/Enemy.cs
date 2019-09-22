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

    private Camera cam;

    public EnemyState enemy_state
    {
        set { state = value; }
        get { return this.state; }
    }

    public float speed
    {
        set { enemy.speed = value;  }
        get { return enemy.speed; }
    }

	// Use this for initialization
	void Start()
	{
        state = EnemyState.CHASE;
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
	}

    private void Chase()
    {
       enemy.speed = chase_speed;
       enemy.destination = cam.transform.position;
    }
    private void Patrol()
    {

    }
}
