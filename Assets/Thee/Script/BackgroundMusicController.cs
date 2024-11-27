using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        // ดึง AudioSource จาก GameObject นี้
        audioSource = GetComponent<AudioSource>();

        // เล่นเพลงเมื่อซีนเริ่ม
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
