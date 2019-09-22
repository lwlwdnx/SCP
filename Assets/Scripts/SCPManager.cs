using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCPManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemys;
    List<GameObject> enemy_list = new List<GameObject>();

    private LightUp lightUpScript;

    // Use this for initialization
    void Start()
	{
        GameObject go = GameObject.FindWithTag("LightUp");
        if (go != null) 
        {
            lightUpScript = go.GetComponent<LightUp>();
            //Debug.Log("000");
        }

        enemy_list.Add(GameObject.Instantiate(enemys[0], transform.position, Quaternion.identity));
        enemy_list.Add(GameObject.Instantiate(enemys[0], transform.position, Quaternion.identity));

        foreach (GameObject obj in enemy_list)
        {
            obj.GetComponent<Enemy>().position = new Vector3(10, 0, 0);
            obj.GetComponent<Enemy>().enemy_state = Enemy.EnemyState.PATROL;
        }
        
    }
	
	// Update is called once per frame
	void Update()
	{
        if (lightUpScript.flagLightUp == true) 
        {
            foreach (GameObject obj in enemy_list)
            {
                obj.GetComponent<Enemy>().enemy_state = Enemy.EnemyState.PATROL;
            }
        }
    }
}