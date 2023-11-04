using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 8f;
    public float smoothRotationTime = 0.12f;
    
    float currentVelocity;
    float currentSpeed;
    float speedVelocity;
    public bool hareket;
    Transform cam;
    public FixedJoystick joystick;
    public GameObject el;
    public bool elinde;

    private void Start()
    {
        cam = Camera.main.transform;
    }
    private void Update()
    {
        if(el.transform.childCount == 1)
        {
            elinde = true;
        }
        if (el.transform.childCount < 1)
        {
            elinde = false;
        }


        Vector2 input = new Vector2(joystick.input.x, joystick.input.y);
       
        
        Vector2 inputDir = input.normalized;
      
        if (inputDir == Vector2.zero)
        {
            hareket = false;
           
        }
       
        if (inputDir != Vector2.zero)
        {

            hareket = true;
            float rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg+cam.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVelocity, smoothRotationTime);
        }
        float targetspeed = MoveSpeed * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetspeed, ref speedVelocity,0.1f); 
        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
      
    }
}
