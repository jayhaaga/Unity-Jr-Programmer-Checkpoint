using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{
    public InputField nameInput;
    private void Start()
    {
        InputField.SubmitEvent se = new InputField.SubmitEvent();
        se.AddListener(UpdateName);
        nameInput.onEndEdit = se;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    private void UpdateName(string arg)
    {
        ScoreManager.Instance.Name = arg;
    }
}
