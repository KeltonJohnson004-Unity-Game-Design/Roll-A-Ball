using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public float speed = 5f;
    void Update()
    {
        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
