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
   
    [HideInInspector] public IngredientBase ingredientBase;
    [HideInInspector] public Transform parentAfterDrag;


    public void InitializeIngredient(IngredientBase newIngredient)
    {
        ingImage = GetComponent<Image>();
        canvas = FindAnyObjectByType<Canvas>();
        background = transform.parent.parent.parent.parent.GetComponent<Image>();
        ingredientBase = newIngredient;
        ingImage.sprite = newIngredient.ingSprite;
    }

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
}
