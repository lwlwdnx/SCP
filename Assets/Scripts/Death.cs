using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary") 
        {
            return;
        }

        if (other.tag == "Enemy")
        {
            //Debug.Log("111");
            Time.timeScale = 0.01f;
        }
    }

    // Update is called once per frame
    void Update()
	{
		
	}
}
