using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUp : MonoBehaviour
{

    public float lightDownRange = 3;
    public float lightDownIntensity = 10;
    public float lightUpRange = 40;
    public float lightUpIntensity = 2;

    public float lightDownRangeSpeed = 0.15f;
    //public float lightDownIntensitySpeed = 0.01f;
    public float lightDownRangeLimit = 10;

    public bool flagLightUp = false;

    IEnumerator LightDown()
    {
        while(true)
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
	
	// Update is called once per frame
	void Update()
	{

        if (Input.GetKey(KeyCode.Space))
        {
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
        }

    }
}
