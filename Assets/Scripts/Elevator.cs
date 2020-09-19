using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private Boolean stopped = false;
    private Vector3 directionToStop;
    private float stoppedTime = 0.0f;
    private float storeSpeed;

    public GameObject ElevatorStart;
    public GameObject ElevatorStop;
    public float speed;



    private void Start()
    {
        transform.position = ElevatorStart.transform.position;
        directionToStop = Vector3.Normalize(ElevatorStop.transform.position - ElevatorStart.transform.position);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + (directionToStop * speed);

        if (stoppedTime <= 0.0f)
        {
            if(speed == 0.0f)
            {
                speed = storeSpeed;
            }
            else if (transform.position.y > ElevatorStop.transform.position.y || transform.position.y < ElevatorStart.transform.position.y)
            {
                storeSpeed = -1 * speed;
                speed = 0.0f;
                stoppedTime = 2.0f;

            }
        }
        else
        {
            stoppedTime -= Time.deltaTime;
        }
            
        


    }

    private void OnTriggerStay(Collider other)
    {
       // if (other.transform.position.y < transform.position.y)
        //{
            speed = 0;
       // }
    }
}
