using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : MonoBehaviour
{
    private static BackgroundMusicManager instance;

    private void Awake()
    {
        // ตรวจสอบว่ามี BackgroundMusicManager อยู่แล้วหรือไม่
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // ลบ GameObject ตัวใหม่ออก
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // ทำให้ GameObject ไม่ถูกทำลายเมื่อเปลี่ยนซีน
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // สมัคร event เมื่อซีนโหลด
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // ยกเลิก event เมื่อซีนถูกปิด
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        if (scene.name == "Test") // เปลี่ยนชื่อซีนที่ต้องการ
        {
            GetComponent<AudioSource>().Stop(); // หยุดเสียง
        }
    }
}
