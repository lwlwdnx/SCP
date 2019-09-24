using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{

    public AudioSource audio;

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
        if (Input.GetKey(KeyCode.Return))
        {
            audio = this.GetComponent<AudioSource>();
            audio.Stop();

        }
    }
}
