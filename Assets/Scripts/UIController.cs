using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public GameObject imageClear;

    public GameObject door;

    public GameObject imageDeath;

    public GameObject mainCamera;

    public GameObject restartText;

    private Victory victoryScript;

    private Death deathScript;

    // Use this for initialization
    void Start()
	{
        imageClear.SetActive(false);
        restartText.SetActive(false);

        if (imageClear != null && door != null) 
        {
            victoryScript = door.GetComponent<Victory>();
        }

        imageDeath.SetActive(false);

        if (imageDeath != null && mainCamera != null)
        {
            deathScript = mainCamera.GetComponent<Death>();
        }
    }
	
	// Update is called once per frame
	void Update()
	{
        if (victoryScript.showClear == true)
        {
            imageClear.SetActive(true);
        }
        else
        {
            imageClear.SetActive(false);
        }

        if (deathScript.showDeath == true)
        {
            imageDeath.SetActive(true);
        }
        else
        {
            imageDeath.SetActive(false);
        }

        if (victoryScript.showClear == true || deathScript.showDeath == true) 
        {
            restartText.SetActive(true);
        }
        else
        {
            restartText.SetActive(false);
        }
    }
}
