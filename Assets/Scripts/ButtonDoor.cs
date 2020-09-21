using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoor : MonoBehaviour
{
    public Material material;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            var doors = GameObject.FindGameObjectsWithTag("ButtonDoors");
            foreach(GameObject door in doors)
            {
                Color color = material.color;
                if (door.GetComponent<Renderer>().material.color == new Color(color.r, color.g, color.b, 0) || door.GetComponent<Renderer>().material.color == new Color(color.r, color.g, color.b, 1))
                {
                    if (door.GetComponent<Renderer>().material.color.a == 1)
                    {
                        door.GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 0);
                        door.GetComponent<Collider>().isTrigger = true;
                    }
                    else
                    {
                        door.GetComponent<Renderer>().material =  material;
                        door.GetComponent<Collider>().isTrigger = false;
                    }
                }
            }
        }
    }
}
