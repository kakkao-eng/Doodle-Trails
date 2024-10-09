using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : MonoBehaviour
{
    public Transform player;
    Vector3 offset;

    // Start is called before the first frame update
    private void Start()
    {
        // คำนวณระยะห่างระหว่างกล้องกับผู้เล่น
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    private void Update()
    {
        // อัปเดตตำแหน่งกล้องให้ติดตามผู้เล่นในแกน Y และ Z โดยไม่เปลี่ยนแปลงแกน X
        transform.position = new Vector3(transform.position.x, player.position.y + offset.y, player.position.z + offset.z);
    }
} 