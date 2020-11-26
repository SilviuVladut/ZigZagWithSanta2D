using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences 
{
    public static string EasyDifficulty = "EasyDifficulty";
    public static string MediumDifficulty = "MediumDifficulty";
    public static string HardDifficulty = "HardDifficulty";


    public static string EasyDifficultyHighScore = "EasyDifficultyHighScore";
    public static string MediumDifficultyHighScore = "MediumDifficultyHighScore";
    public static string HardDifficultyHighScore = "HardDifficultyHighScore";


    public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
    public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
    public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

    public static string isMusicOn = "isMusicOn";
    //folosim int ca boolean 1-true 0-false

    public static int GetMusicState()
    {
        return PlayerPrefs.GetInt(GamePreferences.isMusicOn);
    }
    public static void SetMusicState(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.isMusicOn,state);
    }
    public static void SetEasyDifficultyState(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficulty, state);
    }

    public static int GetEasyDifficultyState()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficulty);
    }

    public static void SetMediumDifficultyState(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficulty, state);
    }

    public static int GetMediumDifficultyState()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficulty);
    }
    public static void SetHardDifficultyState(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficulty, state);
    }

    public static int GetHardDifficultyState()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficulty);
    }

    public static int GetEasyDifficultyHighscore()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyHighScore);
    }

    public static void SetEasyDifficultyHighscore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyHighScore, score);
    }

    public static int GetMediumDifficultyHighscore()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyHighScore);
    }

    public static void SetMediumDifficultyHighscore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyHighScore, score);
    }

    public static int GetHardDifficultyHighscore()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficultyHighScore);
    }

    public static void SetHardDifficultyHighscore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyHighScore, score);
    }

    public static int GetEasyDifficultyCoinscore()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyCoinScore);
    }

    public static void SetEasyDifficultyCoinscore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyCoinScore, score);
    }

    public static int GetMediumDifficultyCoinscore()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyCoinScore);
    }

    public static void SetMediumDifficultyCoinscore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyCoinScore, score);
    }

    public static int GetHardDifficultyCoinscore()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficultyCoinScore);
    }

    public static void SetHardDifficultyCoinscore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyCoinScore, score);
    }
}
