using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GamePlayController : MonoBehaviour
{

   
    public static GamePlayController instance;

    [SerializeField]
    private Text scoreText, coinsText, lifeText,gameOverScoreText,gameOverCoinsText;

    [SerializeField]
    private GameObject pausePanel,gameOverPanel;
    
    void Awake()
    {
        
        MakeInstance();
    }
    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }
    

    public void GameOverShowPanel(int finalScore,int finalCoinScore)
    {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = finalScore.ToString();
        gameOverCoinsText.text = finalCoinScore.ToString();
       

    }

   

    public void PlayerDiedRestartTheGame()
    {
        StartCoroutine(PlayerDiedRestart());
    }
    IEnumerator PlayerDiedRestart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SampleScene");

    }
    public void PlayAgain()
    {
        GameManager.instance.gameStartedFromMainMenu = true;
        SceneManager.LoadScene("SampleScene");
    }

 
    public void PauseTheGame()
    {
        Time.timeScale = 0f; //practic oprim timpul
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; //time scale afecteaza tot animatiile tot din joc de asta trebuie sa l punem pe 1 cand terminam de pus pauza la joc
        SceneManager.LoadScene("MainMenu");
    }

    public void SetScore(int score)
    {
        scoreText.text = "" + score;

    }

    public void SetcoinScore(int coinScore)
    {
        coinsText.text = "x" + coinScore;
    }

    public void SetLifeScore(int lifescore)
    {
        lifeText.text = "x" + lifescore;
    }
}
