using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource sfxSource;

    [Header("UI Sounds")]
    public AudioClip hoverSound;
    public AudioClip clickSound;

    [Header("Weapon Sounds")]
    public AudioClip laserSound;

    [Header("Gameplay Sounds")]
    public AudioClip deathSound;

    public void PlayHover(float volume = 1f)
    {
        if (hoverSound != null)
            sfxSource.PlayOneShot(hoverSound, volume);
    }

    public void PlayClick(float volume = 1f)
    {
        if (clickSound != null)
            sfxSource.PlayOneShot(clickSound, volume);
    }

    public void PlayLaser(float volume = 1f)
    {
        if (laserSound != null)
            sfxSource.PlayOneShot(laserSound, volume);
    }

    public void PlayDeath(float volume = 1f)
    {
        if (deathSound != null)
            sfxSource.PlayOneShot(deathSound, volume);
    }
}