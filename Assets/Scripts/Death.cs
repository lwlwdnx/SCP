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

        if (other.tag == "main camera")
        {
            Debug.Log("111");
        }
    }

    // Update is called once per frame
    void Update()
	{
		
	}
}
