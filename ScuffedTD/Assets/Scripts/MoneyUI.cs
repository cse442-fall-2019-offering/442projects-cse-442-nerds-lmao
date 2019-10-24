using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{

    public Text moneyText;

    void Start()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
