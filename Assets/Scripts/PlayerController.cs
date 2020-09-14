using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.0f;
    public TextMeshProUGUI countText;
    public GameObject WinTextObject;

    private Rigidbody rb;
    
    private float movementX;
    private float movementY;

    private int pickupCount;
    private int goalCount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pickupCount = 0;
        SetCountText();
        WinTextObject.SetActive(false);
        var goals = GameObject.FindGameObjectsWithTag("Pickup");
        goalCount = goals.Length;
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void SetCountText()
    {
        countText.text = "Count: " + pickupCount.ToString();

        if(pickupCount >= goalCount)
        {
            WinTextObject.SetActive(true);
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



}
