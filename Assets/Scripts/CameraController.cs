using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float moveSpeed_Keyboard = 10.0f;
    public float rotateSpeed_Mouse = 0.3f;

    private bool m_Mouse = false;
    private float m_LastMousePosX = 0.0f;
    private float m_LastMousePosY = 0.0f;

    private UIController uicontrollerScript;

    public GameObject uicontroller;

    private bool once = true;

    // Use this for initialization
    void Start()
	{
        if (uicontroller != null)
        {
            uicontrollerScript = uicontroller.GetComponent<UIController>();
        }
    }
	
	// Update is called once per frame
	void Update()
	{
        float fMoveDeltaX = 0.0f;
        float fMoveDeltaZ = 0.0f;
        float fDeltaTime = Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            fMoveDeltaZ += moveSpeed_Keyboard * fDeltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            fMoveDeltaZ -= moveSpeed_Keyboard * fDeltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            fMoveDeltaX -= moveSpeed_Keyboard * fDeltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            fMoveDeltaX += moveSpeed_Keyboard * fDeltaTime;
        }
        if (fMoveDeltaX != 0.0f || fMoveDeltaZ != 0.0f) 
        {
            Vector3 kForward = new Vector3(transform.forward.x, 0, transform.forward.z);
            Vector3 kRight = transform.right;
            Vector3 kUp = transform.up;
            Vector3 kNewPos = transform.position;
            kNewPos += kRight * fMoveDeltaX;
            kNewPos += kForward * fMoveDeltaZ;
            transform.position = kNewPos;
        }

        if (Input.GetKey(KeyCode.Return))
        {
            if(m_Mouse==false)
            {
                m_Mouse = true;
                Vector3 kMousePos = Input.mousePosition;
                m_LastMousePosX = kMousePos.x;
                m_LastMousePosY = kMousePos.y;
            }
            if (once == true)
            {
                once = false;
                uicontrollerScript.started = true;
            }
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            if (m_Mouse == true)
            {
                m_Mouse = false;
                m_LastMousePosX = 0;
                m_LastMousePosY = 0;
            }
        }
        if(m_Mouse == true)
        {
            Vector3 kMousePos = Input.mousePosition;
            float fDeltaX = m_LastMousePosX - kMousePos.x;
            float fDeltaY = m_LastMousePosY - kMousePos.y;
            m_LastMousePosX = kMousePos.x;
            m_LastMousePosY = kMousePos.y;

            Vector3 kNewEuler = transform.eulerAngles;
            kNewEuler.x += fDeltaY * rotateSpeed_Mouse;
            kNewEuler.y += -fDeltaX * rotateSpeed_Mouse;
            transform.eulerAngles = kNewEuler;
        }

        Vector3 mouseRotation = gameObject.transform.eulerAngles;
        if (mouseRotation.x <= 180.0f) 
        {
            if(mouseRotation.x > 60.0f)
            {
                mouseRotation.x = 60.0f;
            }
        }
        if (mouseRotation.x >= 180.0f)
        {
            if(mouseRotation.x < 325.0f)
            {
                mouseRotation.x = 325.0f;
            }
        }
        gameObject.transform.eulerAngles = mouseRotation;

    }
}
