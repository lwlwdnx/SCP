using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{

    public bool showClear = false;

    private bool restart = false;

    // Use this for initialization
    void Start()
	{
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MainCamera") 
        {
            Time.timeScale = 0.01f;
            restart = true;
            showClear = true;
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
                showClear = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
