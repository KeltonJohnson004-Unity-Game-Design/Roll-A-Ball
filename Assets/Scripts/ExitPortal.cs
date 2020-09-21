using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortal : MonoBehaviour
{
    public SceneAsset nextScene;
    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Player"))
        {
            //SceneManager.LoadScene("MiniGame");
            SceneManager.LoadScene(nextScene.name);
        }
    }
}
