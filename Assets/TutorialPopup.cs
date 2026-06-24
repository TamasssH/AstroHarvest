using UnityEngine;

public class TutorialPopup : MonoBehaviour
{
    public float displayTime = 10f;

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip popupSound;

    void Start()
    {
        // Speel geluid af wanneer popup verschijnt
        if (audioSource != null && popupSound != null)
        {
            audioSource.PlayOneShot(popupSound);
        }

        Invoke(nameof(HidePopup), displayTime);
    }

    void HidePopup()
    {
        gameObject.SetActive(false);
    }
}