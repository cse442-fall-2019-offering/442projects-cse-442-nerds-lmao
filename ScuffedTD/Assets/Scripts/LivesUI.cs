using UnityEngine;
using UnityEngine.UI;


public class LivesUI : MonoBehaviour
{
    public Text livesText;

    void Start()
    {
        livesText.text = PlayerStats.Lives.ToString();

    }

    void Update()
    {
        livesText.text = PlayerStats.Lives.ToString();
    }
}


