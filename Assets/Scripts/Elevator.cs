using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    private Vector3 directionToStop;
    private float stoppedTime = 0.0f;
    private float storeSpeed;
    private float distance;
    private Boolean isMoving = true;

    public GameObject ElevatorStart;
    public GameObject ElevatorStop;
    public GameObject EnableElevator;
    public GameObject DisableElevator;
    public GameObject SelfElevator;
    public float speed;



    private void Start()
    {
        transform.position = ElevatorStart.transform.position;
        directionToStop = Vector3.Normalize(ElevatorStop.transform.position - ElevatorStart.transform.position);
        distance = Vector3.Distance(ElevatorStop.transform.position, ElevatorStart.transform.position);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
        {
            transform.position = transform.position + (directionToStop * speed);
            distance -= Mathf.Abs(speed);

            if (stoppedTime <= 0.0f)
            {
                if (speed == 0.0f)
                {
                    distance = Vector3.Distance(ElevatorStop.transform.position, ElevatorStart.transform.position);
                    speed = storeSpeed;
                }
                //else if (transform.position == ElevatorStop.transform.position || transform.position == ElevatorStart.transform.position)
                else if (distance < 0)
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

    }

    private void OnTriggerStay(Collider other)
    {
        if (!EnableElevator.CompareTag("Placeholder") || !DisableElevator.CompareTag("Placeholder") || other.CompareTag("Pickup"))
        {
            EnableElevator.SetActive(true);
            EnableElevator.layer = 0;
           // DisableElevator.layer = 8;
        }
        else if (other.CompareTag("Player"))
        {
            speed = 0;
            isMoving = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && EnableElevator.CompareTag("Placeholder") && DisableElevator.CompareTag("Placeholder"))
        {

            speed = storeSpeed;
            isMoving = true;

        }
        else if(!other.CompareTag("Pickup"))
        {
            SelfElevator.layer = 8;
            DisableElevator.layer = 8;
        }
    }
}
