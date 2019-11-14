using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsInitilizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("volume", -1) < 0)
        {
            PlayerPrefs.SetFloat("volume", (float)0.5);

        }
        AudioListener.volume = PlayerPrefs.GetFloat("volume");

        if (PlayerPrefs.GetInt("difficulty", -1) < 0)
        {
            PlayerPrefs.SetInt("difficulty", 1);

        }
        Debug.Log(PlayerPrefs.GetInt("difficulty", -1));
    }

}
