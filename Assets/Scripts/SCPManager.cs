using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCPManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemys;
    GameObject enemy_list;

    // Use this for initialization
    void Start()
	{
		enemy_list = GameObject.Instantiate(enemys[0], transform.position, Quaternion.identity);

        enemy_list.GetComponent<Enemy>().position = new Vector3(10,0,0);
        enemy_list.GetComponent<Enemy>().enemy_state = Enemy.EnemyState.CHASE;
    }
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
