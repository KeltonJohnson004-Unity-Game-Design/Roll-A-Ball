using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{

    private static Boolean hintActive = false;
    public GameObject hint;
    public GameObject needHint;

    private void Start()
    {
        if (!hintActive)
        { hint.SetActive(false); }
        else { needHint.SetActive(false); }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && !hintActive)
        {
            hintActive = true;
            needHint.SetActive(false);
            hint.SetActive(true);
        }
    }
}
