using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadLevel(int sceneIndex)
    {
        //runs LoadScene function from SceneManagement library with sceneIndex value passed in
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        //Quits the application
        Application.Quit();
#if UNITY_EDITOR //if run within the Unity Editor
        UnityEditor.EditorApplication.isPlaying = false; //sets isPlaying to false
#endif
    }
}
