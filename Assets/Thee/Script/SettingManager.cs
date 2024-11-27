using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
      [SerializeField] private GameObject settingsPanel; // อ้างอิงถึง SettingsPanel

      // ฟังก์ชันสำหรับเปิดหน้าต่าง Settings
       public void OpenSettings()
       {
           settingsPanel.SetActive(true); // แสดงหน้าต่าง
       }

       // ฟังก์ชันสำหรับปิดหน้าต่าง Settings
       public void CloseSettings()
       {
           settingsPanel.SetActive(false); // ซ่อนหน้าต่าง
       }
    
}
