using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{

    private bool batteryInRange = false;

    //public GameObject batteryLight;

    public float lightDownRange = 12;
    public float lightDownIntensity = 5;
    public float lightUpRange = 150;
    public float lightUpIntensity = 2;

    public float lightDownRangeSpeed = 0.8f;
    //public float lightDownIntensitySpeed = 0.01f;
    public float lightDownRangeLimit = 30;

    public bool flagLightUp = false;

    //public float lightUpCoolDown = 3.0f;
    public bool lightCoolDown = true;

    IEnumerator LightDown()
    {
        while (true)
        {
            GetComponent<Light>().range -= lightDownRangeSpeed;
            //GetComponent<Light>().intensity += lightDownIntensitySpeed;
            yield return new WaitForSeconds(0.1f);
        }
    }


    // Use this for initialization
    void Start()
	{
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera") 
        {
            batteryInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            batteryInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
	{
        if (Input.GetKey(KeyCode.E) && lightCoolDown == true && batteryInRange == true) 
        {
            lightCoolDown = false;
            flagLightUp = true;
            GetComponent<Light>().range = lightUpRange;
            GetComponent<Light>().intensity = lightUpIntensity;

            StartCoroutine("LightDown");
        }

        if (GetComponent<Light>().range < lightDownRangeLimit)
        {
            StopCoroutine("LightDown");

            GetComponent<Light>().range = lightDownRange;
            GetComponent<Light>().intensity = lightDownIntensity;

            flagLightUp = false;
            lightCoolDown = true;
        }

    }
}
