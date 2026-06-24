using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomCursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        SetCustomCursor();
        UpdateCursorState();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetCustomCursor();
        UpdateCursorState();
    }

    private void SetCustomCursor()
    {
        if (cursorTexture != null)
        {
            Vector2 hotspot = new Vector2(
                cursorTexture.width / 2,
                cursorTexture.height / 2
            );

            Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
        }
    }

    private void UpdateCursorState()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "GAME")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}