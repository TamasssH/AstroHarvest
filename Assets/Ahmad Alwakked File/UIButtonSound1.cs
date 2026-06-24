using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public SoundManager soundManager;

    public void OnPointerEnter(PointerEventData eventData)
    {
        soundManager.PlayHover();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        soundManager.PlayClick();
    }
}