using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public GameObject ScoreDisplay;
    public static int ScoreCount = 0;   // คะแนนที่แสดงผล
    public float accumulatedScore = 0; // คะแนนสะสมที่ใช้คำนวณจริง
    public int ScoreRate = 1;          // อัตราการเพิ่มคะแนน
    public bool isScore = true;
    public GameObject ScoreEnd;
    public FirebaseRankingManager firebaseManager;
    public OtherSceneManager otherSceneManager;// ลิงก์ไปยัง FirebaseRankingManager
    
    public string playerName = "BOB"; // ชื่อผู้เล่น (ค่าเริ่มต้นคือ BOB)

    // Update is called once per frame
    void Update()
    {
        if (isScore)
        {
            // คำนวณคะแนนสะสมจากเวลา
            accumulatedScore += ScoreRate * (Time.deltaTime * 10);

            // ปัดเศษลงเพื่อเพิ่มค่าใน ScoreCount
            ScoreCount = Mathf.FloorToInt(accumulatedScore);

            // อัปเดต UI ของคะแนน
            ScoreDisplay.GetComponent<TMP_Text>().text = "" + ScoreCount;
            ScoreEnd.GetComponent<TMP_Text>().text = "" + ScoreCount;
        }
    }

    public void StopCount()
    {
        isScore = false; // หยุดการนับคะแนน

        // ตรวจสอบว่า FirebaseRankingManager พร้อมใช้งานหรือไม่
        if (FirebaseRankingManager.Instance != null)
        {
            // ตั้งค่าชื่อผู้เล่นและคะแนนปัจจุบัน
            FirebaseRankingManager.Instance.currentPlayerData.playerName = playerName;
            FirebaseRankingManager.Instance.currentPlayerData.playerScore = ScoreCount;

            // อัปเดตคะแนนไปยัง Firebase
            FirebaseRankingManager.Instance.UpdateScoreIfHigher();
        }
        else
        {
            Debug.LogWarning("FirebaseRankingManager instance is not found.");
        }

        // ส่งชื่อผู้เล่นและคะแนนไปที่ OtherSceneManager
        if (otherSceneManager != null)
        {
            otherSceneManager.ReceiveScore(ScoreCount, playerName);
        }
        else
        {
            Debug.LogWarning("OtherSceneManager instance is not found.");
        }
    }
}