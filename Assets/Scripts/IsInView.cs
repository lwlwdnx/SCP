using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInView : MonoBehaviour
{

    bool ObjectIsInView(Vector3 worldPosition)
    {
        Transform cameraTransform = Camera.main.transform;
        Vector2 viewPosition = Camera.main.WorldToViewportPoint(worldPosition);
        Vector3 direction = (worldPosition - cameraTransform.position).normalized;
        float dot = Vector3.Dot(cameraTransform.forward, direction);

        if (dot > 0 && viewPosition.x > 0 && viewPosition.x < 1 && viewPosition.y > 0 && viewPosition.y < 1)
        {
            return true;
        }
        else
        {
            return false;
        }

    }


    // Use this for initialization
    void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		
        if(ObjectIsInView(gameObject.transform.position))
        {
            //Debug.Log("1");
        }
        else
        {
            //Debug.Log("0");
        }

	}
}
