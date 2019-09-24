using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunProcess : MonoBehaviour
{

    [SerializeField] private List<GameObject> battery_list = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
		
	}

    private void OnTriggerStay(Collider other)
    {
        foreach (GameObject obj in battery_list)
        {
            if (other.tag == "Enemy" &&
                obj.GetComponent<Battery>().LightJudge &&
                other.GetComponent<Enemy>().enemy_state != Enemy.EnemyState.STUN)
            {
                other.GetComponent<Enemy>().enemy_state = Enemy.EnemyState.STUN;
                other.GetComponent<Enemy>().stun_time = other.GetComponent<Enemy>().stun_timer;
            }
        }
    }
}
