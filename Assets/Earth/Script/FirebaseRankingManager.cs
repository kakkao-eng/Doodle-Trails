using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using SimpleJSON;
using System.Linq;

[System.Serializable]
public struct Ranking
{
    public List<PlayerData> playerDatas;
}

public class FirebaseRankingManager : MonoBehaviour
{
    public const string url = "https://doodle-trails-default-rtdb.asia-southeast1.firebasedatabase.app";
    public const string secret = "NrMEVArfQw9PvLiyK5r4Ko7pWMSADUwbdWAbeTby";
    
    
    [Header("Main")]
    public RankUIManager rankUIManager;
    public Ranking ranking;
    [Header("New Data")]
    public PlayerData currentPlayerData;
    private List<PlayerData> sortPlayerDatas = new List<PlayerData>();
    
    
    private void CalculateRankFromScore()
    {
        List<PlayerData> sortRankPlayers = new List<PlayerData>();
        sortRankPlayers = ranking.playerDatas. OrderByDescending(data => data.playerScore).ToList();
        for (int i = 0; i < sortRankPlayers.Count; i++)
        {
            PlayerData changedRankNum = sortRankPlayers[i];
            changedRankNum.rankNumber = i + 1;
            sortRankPlayers[i] = changedRankNum;
        }
        ranking.playerDatas = sortRankPlayers;
    }
    public void FindYourDataInRanking()
    {
        rankUIManager.youRankData.playerData = ranking.playerDatas
            .FirstOrDefault(data => data.playerName == currentPlayerData.playerName); rankUIManager.youRankData.UpdateData();
    }
    
    
    [ContextMenu("Set Local Data to Database")]
    public void SetLocalDataToDatabase()
    {
        string urlData = $"{url}/ranking.json?auth={secret}";
        RestClient.Put<Ranking>(urlData, ranking). Then (response =>
        {
            Debug.Log("Upload Data Complete");
        }).Catch(error =>
        {
            Debug.Log("Error to set local ranking data to database");
        });
    }


    public void ReloadSortingData()
    {
        string urlData = $"{url}/ranking/playerDatas.json?auth={secret}";
        RestClient.Get(urlData).Then(response =>
        {
            Debug.Log(response.Text);
            JSONNode jsonNode = JSONNode.Parse(response.Text);
            ranking = new Ranking();
            ranking.playerDatas = new List<PlayerData>();
            for (int i = 0; i < jsonNode.Count; i++)
            {
                ranking.playerDatas.Add(new PlayerData(
                    jsonNode[i]["rankNumber"],
                    jsonNode[i]["playerName"],
                    jsonNode[i]["playerScore"],
                    null));
            }

            CalculateRankFromScore();
            
            string urlPlayerData = $"{url}/ranking/.json?auth={secret}";
            RestClient.Put<Ranking>(urlPlayerData, ranking).Then(response =>
            {
                Debug.Log("Upload Data Complete");
                rankUIManager.playerDatas = ranking.playerDatas;
                rankUIManager.ReloadRankData();
                FindYourDataInRanking();
            }).Catch(error => { Debug.Log("error on set to server"); });
        }).Catch(error => { Debug.Log("Error to get data from server"); });
    }

    private void Start()
    {
        ReloadSortingData();
    }
    
    
    public void AddDatallWithSorting()
    {
        string urlData = $"{url}/ranking/playerDatas.json?auth={secret}";
        RestClient.Get(urlData). Then (response =>
        {
            Debug.Log(response.Text);
            JSONNode jsonNode = JSONNode.Parse(response.Text);
            ranking = new Ranking();
            ranking.playerDatas = new List<PlayerData>(); 
            for (int i = 0; i < jsonNode.Count; i++)
            {
                ranking.playerDatas.Add(new PlayerData(
                    jsonNode[i]["rankNumber"],
                    jsonNode[i]["playerName"],
                    jsonNode[i]["playerScore"],
                    null));
            }
            PlayerData checkPlayerData = ranking.playerDatas.FirstOrDefault(
                data => data.playerName == currentPlayerData.playerName);
            int indexOfPlayer = ranking.playerDatas.IndexOf(checkPlayerData);
            if (checkPlayerData.playerName != null)
            {
                checkPlayerData.playerScore = currentPlayerData.playerScore; ranking.playerDatas [indexOfPlayer] = checkPlayerData;
                
            }
            
            else
            {
                ranking.playerDatas.Add(currentPlayerData);
            }
            CalculateRankFromScore();
            string urlPlayerData = $"{url}/ranking/.json?auth={secret}";
            RestClient.Put<Ranking>(urlPlayerData, ranking). Then (response =>
            {
                Debug.Log("Upload Data Complete");
                rankUIManager.playerDatas = ranking.playerDatas;
                rankUIManager.ReloadRankData();
                FindYourDataInRanking();
            }).Catch(error =>
            {
                Debug.Log("error on set to server");
            });
            
        }).Catch(error =>
        {
            Debug.Log("Error to get data from server");
        });
        
    }
    
    public void UpdateScoreIfHigher()
    {
        string urlData = $"{url}/ranking/playerDatas.json?auth={secret}";

        RestClient.Get(urlData).Then(response =>
        {
            JSONNode jsonNode = JSONNode.Parse(response.Text);
            ranking = new Ranking();
            ranking.playerDatas = new List<PlayerData>();

            for (int i = 0; i < jsonNode.Count; i++)
            {
                ranking.playerDatas.Add(new PlayerData(
                    jsonNode[i]["rankNumber"],
                    jsonNode[i]["playerName"],
                    jsonNode[i]["playerScore"],
                    null));
            }

            // ค้นหาผู้เล่นในฐานข้อมูล Firebase
            PlayerData currentData = ranking.playerDatas.FirstOrDefault(
                data => data.playerName == currentPlayerData.playerName);

            if (currentData.playerName != null)
            {
                // ถ้าคะแนนใหม่มากกว่าคะแนนเดิม
                if (Score.ScoreCount > currentData.playerScore)
                {
                    currentData.playerScore = Score.ScoreCount; // อัปเดตคะแนน
                    int index = ranking.playerDatas.IndexOf(currentData);
                    ranking.playerDatas[index] = currentData; // เปลี่ยนคะแนนใน list
                    Debug.Log("Updated score for player: " + currentData.playerName);
                }
                else
                {
                    Debug.Log("New score is not higher, no update needed.");
                }
            }
            else
            {
                // ถ้าผู้เล่นไม่มีใน Firebase ให้เพิ่มข้อมูลใหม่
                currentPlayerData.playerScore = Score.ScoreCount;
                ranking.playerDatas.Add(currentPlayerData);
                Debug.Log("Added new player: " + currentPlayerData.playerName);
            }

            // อัปเดตข้อมูลกลับไปยัง Firebase
            string urlPlayerData = $"{url}/ranking/.json?auth={secret}";
            RestClient.Put<Ranking>(urlPlayerData, ranking).Then(response =>
            {
                Debug.Log("Upload data complete.");
                rankUIManager.playerDatas = ranking.playerDatas;
                rankUIManager.ReloadRankData();
                FindYourDataInRanking(); // อัปเดต UI
            }).Catch(error =>
            {
                Debug.LogError("Failed to upload data: " + error);
            });
        }).Catch(error =>
        {
            Debug.LogError("Failed to fetch data: " + error);
        });
    }
}