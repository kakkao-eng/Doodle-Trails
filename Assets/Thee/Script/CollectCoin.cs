using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectCoin : MonoBehaviour
{
    public TMP_Text coinDisplayInGame; 
    public TMP_Text coinDisplayAtEnd; 

    void Update()
    {
        UpdateCoinDisplay();
    }

    public void UpdateCoinDisplay()
    {
        if (coinDisplayInGame != null)
            coinDisplayInGame.text = GameManager.currentCoins.ToString();

        if (coinDisplayAtEnd != null)
            coinDisplayAtEnd.text = GameManager.Instance.totalCoins.ToString();
    }
}
