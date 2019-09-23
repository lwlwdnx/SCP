using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    public bool showDeath = false;

    public bool restart = false;

    private GameObject go;

    private Video videoScript;

    // Use this for initialization
    void Start()
	{
        go = GameObject.FindWithTag("Finish");
        if (go != null)
        {
            videoScript = go.GetComponent<Video>();
            go.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boundary") 
        {
            return;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            go.SetActive(true);
            Time.timeScale = 0.01f;
            //restart = true;
            //showDeath = true;
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
