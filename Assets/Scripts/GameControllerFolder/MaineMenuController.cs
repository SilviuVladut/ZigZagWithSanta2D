using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MaineMenuController : MonoBehaviour
{

    [SerializeField]
    private Button musicBtn;

    [SerializeField]
    private Sprite[] musicIcons;

    void Start()
    {
        CheckToPlayTheMusic();
    }
    void CheckToPlayTheMusic()
    {
        if(GamePreferences.GetMusicState() == 1)
        {
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[0];
        }
        else
        {
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[1];
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
   public void StartGame()
    {
        GameManager.instance.gameStartedFromMainMenu = true;
        SceneManager.LoadScene("SampleScene");
    }

    public void SceneHighScore()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void SceneOptions()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void MusicBtn()
    {
        if(GamePreferences.GetMusicState() == 0)
        {
            GamePreferences.SetMusicState(1);
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[0];
        }else if(GamePreferences.GetMusicState() == 1)
        {
            GamePreferences.SetMusicState(0);
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[1];
        }
    }
}
