using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RankUIManager : MonoBehaviour
{
    public GameObject rankDataPrefab;
    public Transform rankPanel;

    public List<GameObject> createdPlayerDatas = new List<GameObject>();
    public List<PlayerData> playerDatas = new List<PlayerData>();

    // Start is called before the first frame update
    void Start()
    {
        CreateRankData();
    }

    public void CreateRankData()
    {
        for (int i = 0; i < playerDatas.Count; i++)
        {
            GameObject rankObj = Instantiate(rankDataPrefab, rankPanel);
            RankData rankData = rankObj.GetComponent<RankData>();
            rankData.playerData = new PlayerData();
            rankData.playerData.playerName = playerDatas[i].playerName;
            rankData.playerData.playerScore = playerDatas[i].playerScore;
            rankData.playerData.profileSprite = playerDatas[i].profileSprite;
            rankData.playerData.rankNumber = playerDatas[i].rankNumber;
            rankData.UpdateData();
            createdPlayerDatas.Add(rankObj);
        }
    }

    private void ClearRankData()
    {
        foreach (GameObject createdData in createdPlayerDatas)
        {
            Destroy(createdData);
        }
        createdPlayerDatas.Clear();
    }

    private void SortRankData()
    {
        List<PlayerData> sortRankPlayer = playerDatas.OrderByDescending(data => data.playerScore).ToList();

        for (int i = 0; i < sortRankPlayer.Count; i++)
        {
            PlayerData changedRankNum = sortRankPlayer[i];
            changedRankNum.rankNumber = i + 1;
            sortRankPlayer[i] = changedRankNum;
        }
        playerDatas = sortRankPlayer;
    }
    [ContextMenu("Reload")]
    public void ReloadRankData()
    {
        ClearRankData();

        CreateRankData();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
