﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCPManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemys;
    [SerializeField] GameObject battery;
    [SerializeField] GameObject door;
    [SerializeField] GameObject blocks;
    [SerializeField] GameObject box;

    List<GameObject> enemy_list = new List<GameObject>();

    List<GameObject> battery_list = new List<GameObject>();
    List<GameObject> box_list = new List<GameObject>();
    List<GameObject> blocks_list = new List<GameObject>();
    List<GameObject> door_list = new List<GameObject>();

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
            obj.GetComponent<Enemy>().position = new Vector3(20, 0, 0);
            obj.GetComponent<Enemy>().enemy_state = Enemy.EnemyState.PATROL;
        }
        // Generate battery
        battery_list.Add(GameObject.Instantiate(battery, new Vector3(10, 30, 10), Quaternion.identity));
        door_list.Add(GameObject.Instantiate(door, new Vector3(20, 30, 10), Quaternion.identity));
        blocks_list.Add(GameObject.Instantiate(blocks, new Vector3(30, 30, 10), Quaternion.identity));
        box_list.Add(GameObject.Instantiate(box, new Vector3(-10, 30, 10), Quaternion.identity));
    }
	
	// Update is called once per frame
	void Update()
	{
        if (lightUpScript.flagLightUp == true) 
        {
            ChangeEnemyMode(Enemy.EnemyState.CHASE);
        }
        else
        {
            ChangeEnemyMode(Enemy.EnemyState.PATROL);
        }
    }

    private void ChangeEnemyMode(Enemy.EnemyState state)
    {
        foreach (GameObject obj in enemy_list)
        {
            obj.GetComponent<Enemy>().enemy_state = state;
        }
    }
}