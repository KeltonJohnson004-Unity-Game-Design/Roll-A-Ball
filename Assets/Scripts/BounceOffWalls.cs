using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOffWalls : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 bounceMulti;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 velocity = other.GetComponent<Rigidbody>().velocity;
        other.GetComponent<Rigidbody>().velocity = new Vector3(velocity.x * bounceMulti.x, 0, velocity.z * bounceMulti.z);
    }

}
