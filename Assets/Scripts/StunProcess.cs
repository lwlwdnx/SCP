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

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other);
        foreach (GameObject obj in battery_list)
        {
            
        }
    }
}
