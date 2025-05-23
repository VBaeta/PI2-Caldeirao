using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableIngredient : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image background;
    public Image ingImage;
    public Canvas canvas;
    public IngredientBase ingInfo;

    [HideInInspector] public Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        ingImage.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(canvas.transform);
        transform.SetAsLastSibling();
        background.gameObject.SetActive(false);
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        ingImage.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }

    public void InitializeIngredient()
    {
        ingImage.sprite = ingInfo.ingSprite;
    }
}
