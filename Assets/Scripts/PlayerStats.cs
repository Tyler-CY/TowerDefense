using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 1500;

    public static int Lives;
    public int startLives = 20;

    public static int wavesSurvived;
    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        wavesSurvived = 0;
    }
}
