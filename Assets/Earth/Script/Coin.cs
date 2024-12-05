using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip pickupSound; // ลากไฟล์เสียงจาก Inspector
    private AudioSource audioSource; // ตัวเล่นเสียง

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public float turnSpeed = 90f; // ความเร็วในการหมุน

    void Update()
    {
        // หมุนเหรียญรอบแกน Y
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position); // เล่นเสียงที่ตำแหน่งเหรียญ
            }
            // แจ้ง GameManager ว่าผู้เล่นเก็บเหรียญ
            GameManager.Instance.AddCoin(1);

            // ทำลายเหรียญ
            Destroy(gameObject);
        }
    }
}