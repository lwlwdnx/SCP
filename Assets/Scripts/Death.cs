using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    public bool showDeath = false;

    private bool restart = false;

    // Use this for initialization
    void Start()
	{
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boundary") 
        {
            return;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Time.timeScale = 0.01f;
            restart = true;
            showDeath = true;
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
                showDeath = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
