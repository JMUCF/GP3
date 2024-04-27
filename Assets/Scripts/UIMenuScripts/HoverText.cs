using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class HoverTMPText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text alternativeText; // Reference to the alternative TMP Text component

    private TMP_Text defaultText; // Reference to the default TMP Text component
    private bool isHovering = false; // Flag to track if the pointer is hovering over the GameObject

    void Start()
    {
        defaultText = GetComponent<TMP_Text>(); // Get the reference to the default TMP Text component
        alternativeText.gameObject.SetActive(false); // Hide the alternative TMP Text initially
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true; // Set the flag to true when the pointer enters
        alternativeText.gameObject.SetActive(true); // Show the alternative TMP Text
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false; // Set the flag to false when the pointer exits
        alternativeText.gameObject.SetActive(false); // Hide the alternative TMP Text
    }

    void Update()
    {
        // If the pointer is hovering and the alternative text is not active, show it
        if (isHovering && !alternativeText.gameObject.activeSelf)
        {
            alternativeText.gameObject.SetActive(true);
        }
        // If the pointer is not hovering and the alternative text is active, hide it
        else if (!isHovering && alternativeText.gameObject.activeSelf)
        {
            alternativeText.gameObject.SetActive(false);
        }
    }
}
