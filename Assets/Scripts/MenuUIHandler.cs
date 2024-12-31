using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField NameInputField;
    public Text BestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        BestScoreText.text = ScoreManager.Instance.GetBestScoreText();
    }
    public void StartNew()
    {
        
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }

    public void GetPlayerName()
    {
        ScoreManager.Instance.currentPlayerName = NameInputField.text;
    }

}
