using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherSceneManager : MonoBehaviour
{
    private void Awake()
    {
        // Check for FirebaseRankingManager instance at the start
        if (FirebaseRankingManager.Instance != null)
        {
            var ranking = FirebaseRankingManager.Instance.ranking;
        }
        else
        {
            Debug.LogWarning("FirebaseRankingManager instance is not found.");
        }
    }

    public void ReceiveScore(int score, string playerName)
    {
        Debug.Log($"Received score: {score} for player: {playerName}"); // Confirm receipt of score and player

        if (FirebaseRankingManager.Instance != null)
        {
            // Set current player data
            FirebaseRankingManager.Instance.currentPlayerData.playerName = playerName;
            FirebaseRankingManager.Instance.currentPlayerData.playerScore = score;

            // Upload data directly to Firebase
            UpdateScoreInFirebase();
        }
        else
        {
            Debug.LogWarning("FirebaseRankingManager instance is not found.");
        }
    }

    private void UpdateScoreInFirebase()
    {
        FirebaseRankingManager.Instance.UpdateScoreIfHigher(); // Directly update to Firebase
    }
}