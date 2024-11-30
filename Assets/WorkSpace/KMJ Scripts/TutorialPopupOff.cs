using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialPopupOff : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }
}
