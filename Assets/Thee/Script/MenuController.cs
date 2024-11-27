using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public void LoadScene(string GamePlay)
    {
        SceneManager.LoadScene(GamePlay);
        GameManager.Instance.ResetCurrentCoins();
    }

    public void RestartScene()
    {
        GameManager.Instance.ResetCurrentCoins();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    
}
