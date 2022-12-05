using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _tmp;
    [SerializeField] private GameObject _pausePanel;
    public static GameManager instance;
    [SerializeField] private bool _isPaused;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseFunction(true);
        }
        switch (_isPaused)
        {
            case true:
                Time.timeScale = 0;
                break;
            case false:
                Time.timeScale = 1;
                break;
        }
    }

    public void PauseFunction(bool state)
    {
        _pausePanel.gameObject.SetActive(state);
        _isPaused = state;
    }

    public void ReturnToMenu(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void UpdateScoreText(int scoreAmount)
    {
        _tmp.text = "Score: " + scoreAmount.ToString();
    }
}
