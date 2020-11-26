﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinClip, lifeClip;

    private CameraScript cameraScript;

    private Vector3 previousPosition;
    private bool countScore;

    public static int scoreCount;
    public static int lifeCount;
    public static int coinCount;

    void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
        countScore = true;
    }

    // Update is called once per frame
    void Update()
    {
        CountScore();
    }

    void CountScore()
    {
        if (countScore)
        {
            if(transform.position.y < previousPosition.y)
            {
                scoreCount++;
            }
            previousPosition = transform.position;
            GamePlayController.instance.SetScore(scoreCount);
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Coin")
        {
            coinCount++;
            scoreCount += 100;


            GamePlayController.instance.SetScore(scoreCount);
            GamePlayController.instance.SetcoinScore(coinCount);
            

            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            target.gameObject.SetActive(false);
        }

        if(target.tag == "Life")
        {
            lifeCount++;
            scoreCount += 150;


            GamePlayController.instance.SetScore(scoreCount);
            GamePlayController.instance.SetLifeScore(lifeCount);

            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            target.gameObject.SetActive(false);
        }

        if(target.tag == "Bounds" || target.tag == "Deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;
            transform.position = new Vector3(500, 500, 0);//practic aici aruncam playeru afara din ecran sa para ca a murit
            lifeCount--;

            GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);


        }
    }
}
