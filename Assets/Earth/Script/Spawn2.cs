using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = Unity.Mathematics.Random; // การใช้งานการสุ่มจาก Unity Mathematics แต่ไม่ได้ใช้ในโค้ดนี้

public class Spawn2 : MonoBehaviour
{
    Spawn gSpawn;
    public GameObject[] ObstaclePrefabs;
    public GameObject Coin;

    // ตัวแปรสำหรับโอกาสและการเพิ่มโอกาส
    private float obstacleSpawnChance = 0.4f; // โอกาสเริ่มต้น
    private float coinSpawnChance = 0.4f;     // โอกาสเหรียญเริ่มต้น
    private float increaseRate = 0.2f;       // อัตราการเพิ่มโอกาส
    private float maxChance = 0.8f;           // โอกาสสูงสุดที่อุปสรรคสามารถเกิดได้

    // ตัวแปรสำหรับความเร็วการสปาวน์
    private float spawnInterval = 60.0f;       // เวลาเริ่มต้น (วินาที) ระหว่างการสปาวน์
    private float minSpawnInterval = 0.5f;    // ความเร็วสูงสุดที่อนุญาต
    private float spawnSpeedIncreaseRate = 0.1f; // อัตราการเพิ่มความเร็ว

    void Start()
    {
        Debug.Log("Start called");
        gSpawn = GameObject.FindObjectOfType<Spawn>();
        SpawnObstacle();

        InvokeRepeating(nameof(IncreaseSpawnChance), spawnInterval, spawnInterval); 
    }

    private void OnTriggerExit(Collider other)
    {
        gSpawn.SpawnTile();
        Destroy(gameObject, 2);
    }

    void SpawnObstacle()
    {
        float chanceToSpawn = UnityEngine.Random.Range(0f, 1f);

        if (chanceToSpawn < obstacleSpawnChance)
        {
            // Randomly select one obstacle prefab from the array
            int randomObstacleIndex = UnityEngine.Random.Range(0, ObstaclePrefabs.Length);

            // Randomly select a spawn point between child 2 and 4
            int obstacleSpawnIndex = UnityEngine.Random.Range(2, 5);
            Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

            // Instantiate the selected obstacle prefab
            Instantiate(ObstaclePrefabs[randomObstacleIndex], spawnPoint.position, Quaternion.identity, transform);
        }

        float chanceToSpawnCoin = UnityEngine.Random.Range(0f, 1f);
        if (chanceToSpawnCoin < coinSpawnChance)
        {
            // Randomly select a spawn point for the coin
            int coinSpawnIndex = UnityEngine.Random.Range(2, 5);
            Transform coinSpawnPoint = transform.GetChild(coinSpawnIndex).transform;

            // Instantiate the coin prefab
            Instantiate(Coin, coinSpawnPoint.position, Quaternion.identity, transform);
        }
    }

    // ฟังก์ชันสำหรับเพิ่มโอกาสและลดเวลาในการสปาวน์
    private int spawnCallCount = 0;

    void IncreaseSpawnChance()
    {
        spawnCallCount++;
        obstacleSpawnChance = Mathf.Min(obstacleSpawnChance + increaseRate, maxChance);
        Debug.Log(obstacleSpawnChance);

        // เพิ่มความเร็วการสปาวน์
        if (spawnInterval > minSpawnInterval)
        {
            spawnInterval = Mathf.Max(spawnInterval - spawnSpeedIncreaseRate, minSpawnInterval);
            CancelInvoke(nameof(IncreaseSpawnChance)); // ยกเลิกการเรียกซ้ำที่มีอยู่
            InvokeRepeating(nameof(IncreaseSpawnChance), spawnInterval, spawnInterval); // ตั้งค่าความเร็วใหม่
        }
    }
}

