using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public TMP_Text coinText; // ใช้กับ TextMeshPro ลิงก์ไปยัง UI Text ในเมนู

    void Start()
    {
        if (coinText == null)
        {
            Debug.LogError("coinText is not assigned!");
        }
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is not assigned!");
        }

        UpdateCoinText();
    }

    // ฟังก์ชันที่ใช้ในการอัปเดตข้อมูลเหรียญ
    public void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "" + GameManager.Instance.totalCoins;
        }
    }
}
