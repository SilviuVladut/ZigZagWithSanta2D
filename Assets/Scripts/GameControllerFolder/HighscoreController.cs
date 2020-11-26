using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighscoreController : MonoBehaviour
{

    [SerializeField]
    private Text scoreText, coinText;
    // Start is called before the first frame update
    void Start()
    {
        SetScoreBasedOnDifficulty();
    }

    void SetScore(int score,int coinScore)
    {
        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();
    }


    void SetScoreBasedOnDifficulty()
    {
        if(GamePreferences.GetEasyDifficultyState() == 1)
        {
            SetScore(GamePreferences.GetEasyDifficultyHighscore(),GamePreferences.GetEasyDifficultyCoinscore());
        }

        if (GamePreferences.GetMediumDifficultyState() == 1)
        {
            SetScore(GamePreferences.GetMediumDifficultyHighscore(), GamePreferences.GetMediumDifficultyCoinscore());
        }

        if (GamePreferences.GetHardDifficultyState() == 1)
        {
            SetScore(GamePreferences.GetHardDifficultyHighscore(), GamePreferences.GetHardDifficultyCoinscore());
        }
    }
    // Update is called once per frame
   public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
