using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _tmp;
    [SerializeField] private GameObject _pausePanel;
    public static GameManager instance;
    [SerializeField] private bool _isPaused;

    private void Awake()
    {
        //sets instance to this script
        instance = this;
    }

    private void Update()
    {
        //if user inputs Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //runs PauseFunction function
            PauseFunction(true);
        }
        //switch case with isPaused as condition
        switch (_isPaused)
        {
            //case True
            case true:
                //sets timeScale to 0f
                Time.timeScale = 0;
                break;
            //case False
            case false:
                //sets timeScale to 1f
                Time.timeScale = 1;
                break;
        }
    }

    public void PauseFunction(bool state)
    {
        //pausePanel SetActive state is set to the passed in bool state
        _pausePanel.gameObject.SetActive(state);
        //isPaused state is set to the passed in bool state
        _isPaused = state;
    }

    public void ReturnToMenu(int sceneIndex)
    {
        //runs LoadScene from SceneManagement Library with passed in int sceneIndex
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        //quits the application
        Application.Quit();
#if UNITY_EDITOR //if application is run through UnityEditor
        //exits playmode
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void UpdateScoreText(int scoreAmount)
    {
        //sets the TextMeshPro text to "Score" + the passed in int scoreAmount (converted to string)
        _tmp.text = "Score: " + scoreAmount.ToString();
    }
}
