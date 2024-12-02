using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public struct PlayerData
{
    public string playerName;
    public Sprite profileSprite;
    public int rankNumber;
    public int playerScore;


    public PlayerData(int rankNumber, string playerName, int playerScore, Sprite profileSprite)
    {
        this.playerName = playerName ?? string.Empty; // กำหนดค่าเริ่มต้นเป็น String ว่าง
        this.rankNumber = rankNumber;
        this.playerScore = playerScore;
        this.profileSprite = profileSprite; // ควรตรวจสอบ null ด้านนอกกรณีใช้จริง
    }
}


public class RankData : MonoBehaviour
{
    public PlayerData playerData;
    [SerializeField] private Image profileImg;
    [SerializeField] private TMP_Text rankText;
    [SerializeField] private TMP_Text playerNameText;
    [SerializeField] private TMP_Text scoreText;

    public void UpdateData()
    {
        if (profileImg != null && playerData.profileSprite != null)
        {
            profileImg.sprite = playerData.profileSprite;
        }

        if (rankText != null)
        {
            rankText.text = playerData.rankNumber.ToString();
        }

        if (playerNameText != null)
        {
            playerNameText.text = playerData.playerName;
        }

        if (scoreText != null)
        {
            scoreText.text = playerData.playerScore.ToString("0");
        }
    }
}