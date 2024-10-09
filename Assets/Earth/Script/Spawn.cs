using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nexSpawnPos;

    // สร้างพื้นครั้งแรกเมื่อเริ่มเกม
    void Start()
    {
        // สร้างพื้นจำนวน 20 ชิ้นเมื่อเริ่มเกม
        for (int i = 0; i < 20; i++)
        {
            SpawnTile();
        }
    }

    // ฟังก์ชันสร้างพื้นใหม่
    public void SpawnTile()
    {
        // สร้างพื้นใหม่ที่ตำแหน่ง nexSpawnPos
        GameObject temp = Instantiate(groundTile, nexSpawnPos, Quaternion.identity);

        // อัปเดตตำแหน่งถัดไปที่จะใช้สร้างพื้นใหม่
        nexSpawnPos = temp.transform.GetChild(1).transform.position;
    }
}
