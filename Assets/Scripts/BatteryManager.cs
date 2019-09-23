using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryManager : MonoBehaviour
{

    public GameObject mainCamera;
    public GameObject mainLightUp;
    public GameObject battery01;
    public GameObject batteryLight01;
    public GameObject battery02;
    public GameObject batteryLight02;
    public GameObject battery03;
    public GameObject batteryLight03;
    public GameObject battery04;
    public GameObject batteryLight04;
    public GameObject battery05;
    public GameObject batteryLight05;
    public GameObject battery06;
    public GameObject batteryLight06;
    public GameObject battery07;
    public GameObject batteryLight07;
    public GameObject battery08;
    public GameObject batteryLight08;
    public GameObject battery09;
    public GameObject batteryLight09;
    public GameObject battery10;
    public GameObject batteryLight10;

    public bool isLightUp = false;
    public GameObject nowLightUp;
    public Transform nowTransform;

    // Use this for initialization
    void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
        if (mainLightUp.GetComponent<LightUp>().flagLightUp == true)
        {
            isLightUp = true;
            nowLightUp = mainCamera;
            nowTransform = nowLightUp.GetComponent<Transform>();
        }
        else if (batteryLight01.GetComponent<Battery>().flagLightUp == true)
        {
            isLightUp = true;
            nowLightUp = battery01;
            nowTransform = nowLightUp.GetComponent<Transform>();
        }
        else if(batteryLight02.GetComponent<Battery>().flagLightUp == true)
        {
            isLightUp = true;
            nowLightUp = battery02;
            nowTransform = nowLightUp.GetComponent<Transform>();
        }
        else if (batteryLight03.GetComponent<Battery>().flagLightUp == true)
        {
            isLightUp = true;
            nowLightUp = battery03;
            nowTransform = nowLightUp.GetComponent<Transform>();
        }
        else if (batteryLight04.GetComponent<Battery>().flagLightUp == true)
        {
            isLightUp = true;
            nowLightUp = battery04;
            nowTransform = nowLightUp.GetComponent<Transform>();
        }
        else if (batteryLight05.GetComponent<Battery>().flagLightUp == true)
        {
            isLightUp = true;
            nowLightUp = battery05;
            nowTransform = nowLightUp.GetComponent<Transform>();

        }
        else if (batteryLight06.GetComponent<Battery>().flagLightUp == true)
        {
            isLightUp = true;
            nowLightUp = battery06;
            nowTransform = nowLightUp.GetComponent<Transform>();
        }
        else if (batteryLight07.GetComponent<Battery>().flagLightUp == true)
        {
            isLightUp = true;
            nowLightUp = battery07;
            nowTransform = nowLightUp.GetComponent<Transform>();
        }
        else if (batteryLight08.GetComponent<Battery>().flagLightUp == true)
        {
            isLightUp = true;
            nowLightUp = battery08;
            nowTransform = nowLightUp.GetComponent<Transform>();
        }
        else if (batteryLight09.GetComponent<Battery>().flagLightUp == true)
        {
            isLightUp = true;
            nowLightUp = battery09;
            nowTransform = nowLightUp.GetComponent<Transform>();
        }
        else if (batteryLight10.GetComponent<Battery>().flagLightUp == true)
        {
            isLightUp = true;
            nowLightUp = battery10;
            nowTransform = nowLightUp.GetComponent<Transform>();
        }
        else
        {
            isLightUp = false;
        }

    }
}
