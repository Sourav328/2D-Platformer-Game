using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if (GetLevelStatus("Level_1") == LevelStatus.Locked)
        {
            SetLevelStatus("Level_1", LevelStatus.Unlocked);
        }
    }
    public void MarkCurrentLevelComplete()
    {
        string currentLevel = SceneManager.GetActiveScene().name;
        SetLevelStatus(currentLevel, LevelStatus.Completed);

       
        string nextLevel = "Level" + (int.Parse(currentLevel.Replace("Level", "")) + 1);
        if (Application.CanStreamedLevelBeLoaded(nextLevel))
        {
            SetLevelStatus(nextLevel, LevelStatus.Unlocked);
        }
    }
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }
    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }
}