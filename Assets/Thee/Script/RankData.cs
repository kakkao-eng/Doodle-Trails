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
        profileImg.sprite = playerData.profileSprite;
        rankText.text = playerData.rankNumber.ToString();
        playerNameText.text = playerData.playerName;
        scoreText.text = playerData.playerScore.ToString("0");

    }
}
