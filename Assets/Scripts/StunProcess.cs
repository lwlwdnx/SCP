using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunProcess : MonoBehaviour
{

    [SerializeField] private List<GameObject> battery_list = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
		
	}

    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {

    }
}
