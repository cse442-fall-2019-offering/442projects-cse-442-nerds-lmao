using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{

    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;

    public static int levelNumber;
    public int level = 1;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Rounds = 0;
        levelNumber = level;
    }

}
