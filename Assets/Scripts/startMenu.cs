using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{
    [SerializeField] TMP_InputField input;
    [SerializeField] TextMeshProUGUI bestScoreText;
    public void Start()
    {
        GameManager.Instance.LoadScore();
        bestScoreText.text = $"Best score: {GameManager.Instance.bestPlayerName}: {GameManager.Instance.highScore}";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            ExitGame();
        }
    }

    public void StartGame()
    {
        GameManager.Instance.playerName = input.text;
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        GameManager.Instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
