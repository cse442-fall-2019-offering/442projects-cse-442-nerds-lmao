using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeInitialize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("volume", -1) < 0) {
            PlayerPrefs.SetFloat("volume", (float)0.5);

        }
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }

}
