using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LetterDetection : MonoBehaviour, IPointerEnterHandler
{
    public event UnityAction<string> OnTouchEnter;
    TextMeshProUGUI text;
    Image image;
    bool enabled = true;

    void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        image = GetComponent<Image>();
    }

    //When player touches a letter disable it so it can't be pressed more than once
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (enabled)
        {
            OnTouchEnter?.Invoke(text.text);
        }

        enabled = false;
        image.color = Color.blue;
    }

    //Resets letters so they can be used to form words again
    public void EnableLetter()
    {
        enabled = true;
        image.color = Color.white;
    }
}
