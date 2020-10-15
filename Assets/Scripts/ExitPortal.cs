using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortal : MonoBehaviour
{
    //public SceneAsset nextScene;
    public string nextSceneName;
    public int levelToUnlock = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
            {
                PlayerPrefs.SetInt("levelReached", levelToUnlock);
            }

            SceneManager.LoadScene(nextSceneName);
        }
    }
}
