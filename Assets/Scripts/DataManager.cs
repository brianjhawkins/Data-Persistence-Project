using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    private string path;
    public string CurrentName;
    public string HighScoreName;
    public int HighScore;

    // Start is called before the first frame update
    void Awake()
    {
        path = Application.persistentDataPath + "/savefile.json";

        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        Instance = this;
        LoadHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string HighScoreName;
        public int HighScore;
    }

    public void SaveHighScore(int currentScore)
    {
        if (currentScore > HighScore)
        {
            SaveData data = new SaveData();

            data.HighScoreName = CurrentName;
            data.HighScore = currentScore;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(path, json);
        }
    }

    public void LoadHighScore()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScoreName = data.HighScoreName;
            HighScore = data.HighScore;
        }
    }
}
