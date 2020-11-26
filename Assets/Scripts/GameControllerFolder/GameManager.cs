using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

    [HideInInspector]
    public int score, coinScore, lifeScore;

    void Awake()
    {
        MakeSingleton();
    }

    void Start()
    {
        InitializeVariables();
       
    }

  

   void OnEnable()
    {
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= LevelFinishedLoading;
    }

    void LevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "SampleScene")
        {
            if(gameRestartedAfterPlayerDied)
            {
                GamePlayController.instance.SetScore(score);
                GamePlayController.instance.SetcoinScore(coinScore);
                GamePlayController.instance.SetLifeScore(lifeScore);

                PlayerScore.scoreCount = score;
                PlayerScore.coinCount = coinScore;
                PlayerScore.lifeCount = lifeScore;
            } else if(gameStartedFromMainMenu)
            {
                PlayerScore.scoreCount = 0;
                PlayerScore.coinCount = 0;
                PlayerScore.lifeCount = 1;

                GamePlayController.instance.SetScore(0);
                GamePlayController.instance.SetcoinScore(0);
                GamePlayController.instance.SetLifeScore(1);
            }
        }
    }

    void InitializeVariables()
    {
        if (!PlayerPrefs.HasKey("Game Initialized"))
        {
            GamePreferences.SetEasyDifficultyState(0);
            GamePreferences.SetEasyDifficultyHighscore(0);
            GamePreferences.SetEasyDifficultyCoinscore(0);

            GamePreferences.SetMediumDifficultyState(1);
            GamePreferences.SetMediumDifficultyHighscore(0);
            GamePreferences.SetMediumDifficultyCoinscore(0);

            GamePreferences.SetHardDifficultyState(0);
            GamePreferences.SetHardDifficultyHighscore(0);
            GamePreferences.SetHardDifficultyCoinscore(0);

            GamePreferences.SetMusicState(0);

            PlayerPrefs.SetInt("Game Initialized", 123);
            //fara linia de sus de cod daca nu o initializam daca jucatorul intra iar in joc practic i se reseteaza totul si se pune pe 0 pt ca variabila
            //aia nu a fost initializata ca sa memoreze cv;
        }
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void CheckGameStatus(int score,int coinScore,int lifeScore)
    {
        if(lifeScore <= 0)
        {
            if(GamePreferences.GetEasyDifficultyState() == 1)
            {
                int highscore = GamePreferences.GetEasyDifficultyHighscore();
                int coinhighscore = GamePreferences.GetEasyDifficultyCoinscore();

                if (highscore < score)
                    GamePreferences.SetEasyDifficultyHighscore(score);

                if (coinhighscore < coinScore)
                    GamePreferences.SetEasyDifficultyCoinscore(coinScore);
            }

            if (GamePreferences.GetMediumDifficultyState() == 1)
            {
                int highscore = GamePreferences.GetMediumDifficultyHighscore();
                int coinhighscore = GamePreferences.GetMediumDifficultyCoinscore();

                if (highscore < score)
                    GamePreferences.SetMediumDifficultyHighscore(score);

                if (coinhighscore < coinScore)
                    GamePreferences.SetMediumDifficultyCoinscore(coinScore);
            }

            if (GamePreferences.GetHardDifficultyState() == 1)
            {
                int highscore = GamePreferences.GetHardDifficultyHighscore();
                int coinhighscore = GamePreferences.GetHardDifficultyCoinscore();

                if (highscore < score)
                    GamePreferences.SetHardDifficultyHighscore(score);

                if (coinhighscore < coinScore)
                    GamePreferences.SetHardDifficultyCoinscore(coinScore);
            }

            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = false;

            GamePlayController.instance.GameOverShowPanel(score, coinScore);
        }
        else
        {
            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;

         

            gameRestartedAfterPlayerDied = true;
            gameStartedFromMainMenu = false;

            GamePlayController.instance.PlayerDiedRestartTheGame();

        }
    }

}
