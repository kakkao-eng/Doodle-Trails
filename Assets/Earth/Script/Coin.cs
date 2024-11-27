using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;


public class Coin : MonoBehaviour
{

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
            // แจ้ง GameManager ว่าผู้เล่นเก็บเหรียญ
            GameManager.Instance.AddCoin(1);

            // ทำลายเหรียญ
            Destroy(gameObject);
        }
    }
}
