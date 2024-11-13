using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Obstacle : MonoBehaviour
{
    public Test player;
    //public Score score;
    public GameObject endScreen;
    public GameObject ScoreCount;
    //private Test playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        //playerMovement = GameObject.FindObjectOfType<Test>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("obstacle"))
        {
            Debug.Log("Player hit the obstacle!");

            player.StopMove();
            //score.StopCount();
            endScreen.SetActive(true);
            ScoreCount.SetActive(false);
        }


        /*if (collision.gameObject.name == "Player")
        {
            playerMovement.Die();
        }*/
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
