using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int score = 0;
    private List<int> coins = new List<int>();
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("Spel Start");
        }
    }

    // update every frame lmao
    void Update()
    {
      if (score >= 50)
        {
            Debug.Log("win GG");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // voeg 10 coins toe
            Addcoin(10);
        }
    }
    public void Addcoin(int coinValue)
    {
        coins.Add(coinValue);
        score += coinValue;
        Debug.Log("+munt  Score: " + score);
    }

    // ts so buns 
}
