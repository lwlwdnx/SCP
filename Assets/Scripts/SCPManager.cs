using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCPManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemys;
    List<GameObject> enemy_list = new List<GameObject>();

    // Use this for initialization
    void Start()
	{
		enemy_list.Add(GameObject.Instantiate(enemys[0], transform.position, Quaternion.identity));

        foreach (GameObject obj in enemy_list)
        {
            obj.GetComponent<Enemy>().position = new Vector3(10, 0, 0);
            obj.GetComponent<Enemy>().enemy_state = Enemy.EnemyState.CHASE;
        }
    }
	
	// Update is called once per frame
	void Update()
	{
		
	}
}