using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float force;
    private float cooldown = .5f;
    private float timer = 0.0f;
    private Boolean bounceIsReady = true; 


    private void Update()
    {
        if (!bounceIsReady)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                bounceIsReady = true;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (bounceIsReady)
        {
            if (other.CompareTag("Player"))
            {
            
                Vector3 direction = new Vector3(other.transform.position.x - transform.position.x, 0, other.transform.position.z - transform.position.z);
                direction = Vector3.Normalize(direction);
                other.GetComponent<Rigidbody>().AddForce(direction * force);
                bounceIsReady = false;
                timer = cooldown;
            }
        }
    }
}
