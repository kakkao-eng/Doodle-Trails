using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    public GameObject ScoreDisplay;
    public int ScoreCount = 0;         // คะแนนที่แสดงผล
    public float accumulatedScore = 0; // คะแนนสะสมที่ใช้คำนวณจริง
    public int ScoreRate = 1;          // อัตราการเพิ่มคะแนน
    public bool isScore = true;

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
        }
    }


}
