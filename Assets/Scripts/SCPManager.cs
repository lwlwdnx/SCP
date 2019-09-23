using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCPManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemys;
    [SerializeField] GameObject battery;
    [SerializeField] GameObject door;
    [SerializeField] GameObject blocks;
    [SerializeField] GameObject box;

    [SerializeField] List<GameObject> enemy_list = new List<GameObject>();

    private BatteryManager batteryManagerScript;

    // Use this for initialization
    void Start()
	{
        GameObject go = GameObject.FindWithTag("BatteryManager");
        if (go != null) 
        {
            batteryManagerScript = go.GetComponent<BatteryManager>();
            //Debug.Log("000");
        }
        int route_index = 0;
        foreach (GameObject obj in enemy_list)
        {
            obj.GetComponent<Enemy>().position = new Vector3(0, 0, 0);
            obj.GetComponent<Enemy>().enemy_state = Enemy.EnemyState.PATROL;
            obj.GetComponent<Enemy>().patrol_pattern_ = route_index++;
        }
    }
	
	// Update is called once per frame
	void Update()
	{
        if (batteryManagerScript.isLightUp == true) 
        {
            SetLightPosition(batteryManagerScript.nowTransform.position);
            AllChangeEnemyModeExceptStakeAndStun(Enemy.EnemyState.CHASE);
        }
    }

    private void SetLightPosition(Vector3 pos)
    {
        foreach (GameObject obj in enemy_list)
        {
            obj.GetComponent<Enemy>().light_position = pos;
        }
    }
    private void AllChangeEnemyMode(Enemy.EnemyState state)
    {
        foreach (GameObject obj in enemy_list)
        {
            obj.GetComponent<Enemy>().enemy_state = state;
        }
    }
    private void ChangeEnemyMode(GameObject obj, Enemy.EnemyState state)
    {
        obj.GetComponent<Enemy>().enemy_state = state;
    }
    private void AllChangeEnemyModeExceptStake(Enemy.EnemyState state)
    {
        foreach (GameObject obj in enemy_list)
        {
            if (obj.GetComponent<Enemy>().enemy_state != Enemy.EnemyState.STAKE) ChangeEnemyMode(obj,state);
        }
    }
    private void AllChangeEnemyModeExceptStakeAndStun(Enemy.EnemyState state)
    {
        foreach (GameObject obj in enemy_list)
        {
            if (obj.GetComponent<Enemy>().enemy_state != Enemy.EnemyState.STAKE && obj.GetComponent<Enemy>().enemy_state != Enemy.EnemyState.STUN) ChangeEnemyMode(obj, state);
        }
    }
}
