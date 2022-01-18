using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public string Name;
    public string HighScoreName;
    public int HighScore;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }
    [System.Serializable]
    class SaveData
    {
        public string Name;
        public int Score;
    }
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.Name = HighScoreName;
        data.Score = HighScore;
        File.WriteAllText(Application.persistentDataPath + "/highscore.json", JsonUtility.ToJson(data));
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if(File.Exists(path))
        {
            SaveData data = JsonUtility.FromJson<SaveData>(File.ReadAllText(path));
            HighScore = data.Score;
            HighScoreName = data.Name;
        }
    }
    public void UpdateHighScore(int score)
    {
        if(score > HighScore)
        {
            HighScore = score;
            HighScoreName = Name;
            SaveHighScore();
        }
    }
}
