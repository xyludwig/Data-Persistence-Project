using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int bestScore;
    public string bestPlayerName;
    public string currentPlayerName;
    public static ScoreManager Instance;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestRecord();

    }

    [System.Serializable]
    class SaveData
    {
        public int BestScore;
        public string BestPlayerName;
    }

    public void SaveBestScore(int newBestScore)
    {
        SaveData saveData = new SaveData();
        saveData.BestScore = newBestScore;
        saveData.BestPlayerName = currentPlayerName;
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadBestRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            bestScore = saveData.BestScore;
            bestPlayerName = saveData.BestPlayerName;
        }
    }

    public bool IsBestScore(int m_Points)
    {
        return (m_Points > bestScore);

    }

    public void UpdateBestScore(int m_Points)
    {
        bestScore = m_Points;
        bestPlayerName = currentPlayerName;
        SaveBestScore(bestScore);
    }

    public string GetBestScoreText()
    {
        return $"Best Score : {bestPlayerName} {bestScore}";
    }

}
