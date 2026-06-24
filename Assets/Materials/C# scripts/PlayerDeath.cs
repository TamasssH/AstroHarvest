using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject loseCanvas;

    void Start()
    {
        if (loseCanvas) loseCanvas.SetActive(false);
    }

    public void OnDeath()
    {
        if (loseCanvas) loseCanvas.SetActive(true);
        Time.timeScale = 0f; 
    }
}