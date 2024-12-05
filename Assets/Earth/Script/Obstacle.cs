
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class Obstacle : MonoBehaviour
{
    // อ้างอิงถึงสคริปต์และ GameObject ต่างๆ
    public Test player;                    // สคริปต์ที่ควบคุมการเคลื่อนที่ของผู้เล่น
    public Score score;                    // สคริปต์จัดการคะแนน
    public GameObject endScreen;           // จอแสดงผลเมื่อเกมจบ
    public GameObject ScoreCount;          // UI แสดงคะแนนขณะเล่น
    public GameObject UIControl;           // UI ควบคุมอื่นๆ
    public BackgroundMusicController musicController; // ควบคุมเพลงพื้นหลัง
    public AudioClip pickupSound; // ลากไฟล์เสียงจาก Inspector
    private AudioSource audioSource; // ตัวเล่นเสียง


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // หากไม่ได้ตั้งค่าตัวแปรใน Inspector อาจค้นหา GameObject อัตโนมัติ
        if (player == null)
        {
            player = GameObject.FindObjectOfType<Test>();
        }

        if (score == null)
        {
            score = GameObject.FindObjectOfType<Score>();
        }

        if (musicController == null)
        {
            musicController = GameObject.FindObjectOfType<BackgroundMusicController>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่าเป็นสิ่งกีดขวางหรือไม่
        if (other.CompareTag("obstacle"))
        {
            Debug.Log("Player hit the obstacle!");
            #if UNITY_IOS || UNITY_ANDROID
            Handheld.Vibrate();
            #endif

            // ส่งข้อความดีบัคเพื่อแจ้งว่าได้สั่นแล้ว
            Debug.Log("Vibration triggered");
            // หยุดเพลงพื้นหลัง
            if (musicController != null)
            {
                musicController.StopMusic();
            }
            if (pickupSound != null)
            {
                audioSource.PlayOneShot(pickupSound);
            }
            // หยุดการเคลื่อนที่และการเพิ่มคะแนน
            if (player != null)
            {
                player.StopMove();
            }

            if (score != null)
            {
                score.StopCount();
            }

            // แสดงจอเกมจบและซ่อน UI
            if (endScreen != null)
            {
                
                endScreen.SetActive(true);
            }

            if (ScoreCount != null)
            {
                ScoreCount.SetActive(false);
            }

            if (UIControl != null)
            {
                UIControl.SetActive(false);
            }
        }
    }
}
