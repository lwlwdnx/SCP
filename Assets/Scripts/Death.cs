using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    private bool restart = false;

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
            restart = true;
        }
    }

    // Update is called once per frame
    void Update()
	{
        if (restart == true)
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                Time.timeScale = 1;
                restart = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
