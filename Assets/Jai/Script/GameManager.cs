using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance

    public int totalCoins = 0; // จำนวนเหรียญทั้งหมดที่เก็บได้
    public static int currentCoins = 0; // จำนวนเหรียญในซีนปัจจุบัน

    private void Awake()
    {
        //สร้าง Singleton เพื่อให้ GameManager คงอยู่ระหว่างซีน
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddCoin(int amount)
    {
        currentCoins += amount; // เพิ่มเหรียญในซีนปัจจุบัน
        totalCoins += amount;   // เพิ่มเหรียญรวมทั้งหมด
        Debug.Log($"Coin added! Current Coins: {currentCoins}, Total Coins: {totalCoins}");
    }

    public void ResetCurrentCoins()
    {
        currentCoins = 0; // รีเซ็ตเฉพาะเหรียญในซีน
        Debug.Log("Current coins reset to 0");
    }
}
