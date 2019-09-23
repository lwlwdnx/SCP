using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{

    //public VideoPlayer videoPlayer;

    private GameObject go;

    private Death deathScript;

    // Use this for initialization
    void Start()
	{
        go = GameObject.FindWithTag("MainCamera");
        if (go != null)
        {
            deathScript = go.GetComponent<Death>();
        }
    }

    void EndReached(VideoPlayer vp)
    {
        deathScript.restart = true;
        deathScript.showDeath = true;
    }

    // Update is called once per frame
    void Update()
	{
        
    }
}
