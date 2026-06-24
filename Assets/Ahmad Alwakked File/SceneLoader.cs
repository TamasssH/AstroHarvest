using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            string sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == "GAME")
            {
                SceneManager.LoadScene("Settings");
            }
            else if (sceneName == "Settings")
            {
                SceneManager.LoadScene("GAME");
            }
            else if (sceneName == "Creators")
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GAME");
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
        SceneManager.LoadScene("GAME");
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