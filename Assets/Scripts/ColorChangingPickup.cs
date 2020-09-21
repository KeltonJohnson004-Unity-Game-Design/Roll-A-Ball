using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class ColorChangingPickup : MonoBehaviour
{
    public Material changeToMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {


            other.GetComponent<Renderer>().material = changeToMaterial;
            var doors = GameObject.FindGameObjectsWithTag("Doors");
           
            
            foreach(GameObject door in doors)
            {
                if (door.GetComponent<Renderer>().material.color == changeToMaterial.color)
                {
                   
                    door.GetComponent<Collider>().isTrigger = true;
                }
                else
                {
                    door.GetComponent<Collider>().isTrigger = false;
                }
            }
        }
    }
}
