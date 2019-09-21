﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float moveSpeed_Keyboard_forward = 10.0f;
    public float moveSpeed_Keyboard_back = 5.0f;
    public float rotateSpeed_Mouse = 0.2f;

    private bool m_Mouse = false;
    private float m_LastMousePosX = 0.0f;
    private float m_LastMousePosY = 0.0f;


    // Use this for initialization
    void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
        float fMoveDeltaZ = 0.0f;
        float fDeltaTime = Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            fMoveDeltaZ += moveSpeed_Keyboard_forward * fDeltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            fMoveDeltaZ -= moveSpeed_Keyboard_back * fDeltaTime;
        }
        if (fMoveDeltaZ != 0.0f)
        {
            Vector3 kForward = transform.forward;
            Vector3 kRight = transform.right;
            Vector3 kUp = transform.up;
            Vector3 kNewPos = transform.position;
            kNewPos += kForward * fMoveDeltaZ;
            transform.position = kNewPos;
        }

        if (Input.GetKey(KeyCode.L))
        {
            if(m_Mouse==false)
            {
                m_Mouse = true;
                Vector3 kMousePos = Input.mousePosition;
                m_LastMousePosX = kMousePos.x;
                m_LastMousePosY = kMousePos.y;
            }
            else
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


    }
}
