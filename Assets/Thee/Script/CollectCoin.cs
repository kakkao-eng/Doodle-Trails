using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectCoin : MonoBehaviour
{
    public static int coinCount;
    public GameObject coinCountDisplay;

    // Update is called once per frame
    void Update()
    {
        coinCountDisplay.GetComponent<TMP_Text>().text = "" + coinCount;
    }
}
