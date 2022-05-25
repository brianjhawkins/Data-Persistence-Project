using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.Instance != null && !string.IsNullOrEmpty(DataManager.Instance.HighScoreName))
        {
            highScoreText.text = "High Score : " + DataManager.Instance.HighScoreName + " : " + DataManager.Instance.HighScore;
        }
    }

    
    public void ClickStart()
    {
        if (string.IsNullOrEmpty(nameField.text))
        {
            DataManager.Instance.CurrentName = "Unknown";
        }
        else
        {
            DataManager.Instance.CurrentName = nameField.text;
        }

        SceneManager.LoadScene("main");
    }

    public void ClickQuit()
    {
    #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
    #else
                Application.Quit();
    #endif
    }
}
