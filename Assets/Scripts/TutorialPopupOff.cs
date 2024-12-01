using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialPopupOff : MonoBehaviour, IPointerClickHandler
{
    public GameObject nextPanel; 

    void Start()
    {
        if (nextPanel != null)
        {
            nextPanel.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SetActive(false);

        if (nextPanel != null)
        {
            nextPanel.SetActive(true);
        }
    }
}
