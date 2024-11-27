using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    private const string MusicVolumeKey = "musicVolume";
    private const string SFXVolumeKey = "sfxVolume";

    private void Start()
    {
        // โหลดค่าที่บันทึกไว้สำหรับ Music และ SFX
        if (PlayerPrefs.HasKey(MusicVolumeKey))
        {
            LoadVolume();
        }
        else
        {
            // ตั้งค่าเริ่มต้นสำหรับ Music และ SFX
            musicSlider.value = 0.5f; // ค่าเริ่มต้น
            SFXSlider.value = 0.5f;  // ค่าเริ่มต้น
            SetMusicVolume();
            SetSFXVolume();
        }

        // เพิ่ม Event Listener ให้กับ Slider
        musicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });
        SFXSlider.onValueChanged.AddListener(delegate { SetSFXVolume(); });
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume) * 20); // แปลง Slider (Linear) เป็น Decibel
        PlayerPrefs.SetFloat(MusicVolumeKey, volume); // บันทึกค่า Volume
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20); // แปลง Slider (Linear) เป็น Decibel
        PlayerPrefs.SetFloat(SFXVolumeKey, volume); // บันทึกค่า Volume
    }

    private void LoadVolume()
    {
        // โหลดค่าที่บันทึกไว้สำหรับ Music และ SFX
        float savedMusicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 0.5f); // หากไม่มีค่า ใช้ค่าเริ่มต้น 0.5f
        float savedSFXVolume = PlayerPrefs.GetFloat(SFXVolumeKey, 0.5f);   // หากไม่มีค่า ใช้ค่าเริ่มต้น 0.5f

        musicSlider.value = savedMusicVolume;
        SFXSlider.value = savedSFXVolume;

        // ตั้งค่า Volume ใน AudioMixer
        myMixer.SetFloat("Music", Mathf.Log10(savedMusicVolume) * 20);
        myMixer.SetFloat("SFX", Mathf.Log10(savedSFXVolume) * 20);
    }

}
