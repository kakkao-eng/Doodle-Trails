using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = Unity.Mathematics.Random; // การใช้งานการสุ่มจาก Unity Mathematics แต่ไม่ได้ใช้ในโค้ดนี้

public class Spawn2 : MonoBehaviour
{
    // ตัวแปรที่จะใช้ในการอ้างอิงถึงคลาส Spawn อื่นที่จัดการการเกิดของพื้นที่
    Spawn gSpawn;
    
    // ตัวแปรอ้างอิง Prefab ของอุปสรรคที่จะถูกสร้างขึ้น
    public GameObject ObstaclePrefab , Coin;

    // ฟังก์ชันนี้จะถูกเรียกเมื่อเกมเริ่มต้นครั้งแรก
    void Start()
    {
        // ค้นหาออบเจ็กต์ในฉากที่เป็นชนิด Spawn และเก็บไว้ใน gSpawn
        gSpawn = GameObject.FindObjectOfType<Spawn>();
        
        // เรียกฟังก์ชัน SpawnObstacle() เพื่อสร้างอุปสรรคในตำแหน่งที่กำหนด
        SpawnObstacle();
    }

    // ฟังก์ชันนี้จะถูกเรียกเมื่อมีออบเจ็กต์ชนหรือผ่านการ Trigger
    private void OnTriggerExit(Collider other)
    {
        // เรียกใช้ฟังก์ชัน SpawnTile() จากคลาส gSpawn เพื่อสร้างพื้นใหม่
        gSpawn.SpawnTile();
        
        // ทำลายวัตถุนี้หลังจากผ่านไป 2 วินาที
        Destroy(gameObject, 2);
    }

    // ฟังก์ชันนี้จะถูกเรียกทุกเฟรมของเกม แต่ในที่นี้ไม่ได้ใช้งาน
    void Update()
    {
        
    }

    // ฟังก์ชันสำหรับการสุ่มตำแหน่งและสร้างอุปสรรค
    void SpawnObstacle()
    {
        // เพิ่มตัวแปรเพื่อกำหนดโอกาสในการสร้างอุปสรรค
        float chanceToSpawn = UnityEngine.Random.Range(0f, 1f);  // สุ่มค่าเป็นตัวเลขระหว่าง 0 ถึง 1

        // กำหนดโอกาสที่จะสร้างอุปสรรค (ในที่นี้ให้สร้างเมื่อสุ่มได้ค่าต่ำกว่า 0.5)
        if (chanceToSpawn < 0.5f)
        {
            // สุ่มตัวเลขเพื่อเลือกตำแหน่งที่อุปสรรคจะถูกสร้างขึ้น (ในที่นี้จะสุ่มเลข 2 ถึง 4)
            int obstacleSpawnIndex = UnityEngine.Random.Range(2, 5);

            // หา Transform ของตำแหน่งที่ถูกสุ่มในลูกของวัตถุปัจจุบัน
            Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

            // สร้างอุปสรรค (ObstaclePrefab) ในตำแหน่งที่สุ่มได้ พร้อมการหมุนเริ่มต้นที่ไม่หมุน (Quaternion.identity)
            Instantiate(ObstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
        }
        
        float chanceToSpawnCoin = UnityEngine.Random.Range(0f, 1f);
        if (chanceToSpawnCoin < 0.5f)
        {
            // สุ่มตำแหน่งอื่นเพื่อสร้างเหรียญ
            int coinSpawnIndex = UnityEngine.Random.Range(2, 5);
            Transform coinSpawnPoint = transform.GetChild(coinSpawnIndex).transform;

            Instantiate(Coin, coinSpawnPoint.position, Quaternion.identity, transform);
        }
    }
}