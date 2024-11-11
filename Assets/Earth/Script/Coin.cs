using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    public float turmSpeed =90;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(turmSpeed * Time.deltaTime,0,0 );
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่าเป็น Player หรือไม่
        if (other.CompareTag("Player"))
        {
            // ลบวัตถุ Coin ออกจาก Scene
            Destroy(gameObject);

            // สามารถเพิ่มโค้ดสำหรับเพิ่มคะแนนให้ผู้เล่นได้ที่นี่
            // เช่น GameManager.Instance.AddScore(1);
        }
    }
}
