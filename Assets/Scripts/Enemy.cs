using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyState
    {
        WALK,
        TRACE
    };

    [SerializeField] private Vector3 enemy_pos = Vector3.zero;
    [SerializeField] private float speed = 1.0f;

    private GameObject cam_obj;

    private EnemyState state;
    private float move_time = 0.0f;
    private Vector3 target_pos = Vector3.zero;
    private bool rotation_flag = false;

    private System.Func<float,float,float> move_timer = (min,max)=>{ return Random.Range(min,max); };
    private System.Func<Vector3> rand_pos = ()=>{ return new Vector3(Random.Range(10.0f, 10.0f), 1.0f, Random.Range(-10.0f, 10.0f)); };

    // Start is called before the first frame update
    void Start()
    {
        cam_obj = Camera.main.gameObject;
        state = EnemyState.WALK;
        transform.position = enemy_pos;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case EnemyState.WALK:
                RandomMove(); break;
            case EnemyState.TRACE:
                TraceMove(); break;
            default:
                break;
        }
    }

    private void TraceMove()
    {
        target_pos = cam_obj.transform.position;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Quaternion targetRotation = Quaternion.LookRotation(target_pos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime / 2);
    }

    private void RandomMove()
    {
        if (move_time > 0.0f)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(target_pos - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime / 2);
            move_time -= Time.deltaTime;
        }
        else
        {
            ResetPos();
        }
    }
    
    private void ResetPos()
    {
        target_pos = rand_pos();
        move_time = move_timer(5.0f, 10.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        ResetPos();
    }
}
