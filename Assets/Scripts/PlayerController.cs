using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.0f;
    public TextMeshProUGUI countText;
    public GameObject WinTextObject;
    public GameObject spawnPoint;

    private Rigidbody rb;
    
    private float movementX;
    private float movementY;
    private float respawnCooldown = 0.0f;

    private int pickupCount;
    private int goalCount;
    private Boolean respawnReady = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pickupCount = 0;
        SetCountText();
        WinTextObject.SetActive(false);
        var goals = GameObject.FindGameObjectsWithTag("Pickup");
        goalCount = goals.Length;
        rb.transform.position = spawnPoint.transform.position;
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void SetCountText()
    {
        countText.text = "Count: " + pickupCount.ToString() + " / " + goalCount;

        if(pickupCount >= goalCount)
        {
            WinTextObject.SetActive(true);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V) && respawnCooldown <= 0 )
        {
            respawnPlayer();
        }
        if(respawnCooldown > 0)
        {
            respawnCooldown -= Time.deltaTime;
        }
        else if(!respawnReady)
        {
            respawnReady = true;
        }


        
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            pickupCount++;

            SetCountText();
        }

    }

    private void respawnPlayer()
    {
        
        respawnCooldown = 5.0f;
        rb.transform.position = spawnPoint.transform.position;
        rb.velocity = new Vector3(0,0,0);
    }



}
