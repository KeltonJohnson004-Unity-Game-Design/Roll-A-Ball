using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelUnlock : MonoBehaviour
{
    public int levelRequired;

    private void Start()
    {
        if (levelRequired <= PlayerPrefs.GetInt("levelReached", 1))
        {
            gameObject.SetActive(false);
        }
    }

}

