using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            string sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == "Game")
            {
                SceneManager.LoadScene("Game Options");
            }
            else if (sceneName == "Game Options")
            {
                SceneManager.LoadScene("Game");
            }
            else if (sceneName == "Settings")
            {
                SceneManager.LoadScene("MainMenu");
            }
            else if (sceneName == "Creators")
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void OpenCreators()
    {
        SceneManager.LoadScene("Creators");
    }

    public void ReturnToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}