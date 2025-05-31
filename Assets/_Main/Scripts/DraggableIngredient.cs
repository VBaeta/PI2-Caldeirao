using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableIngredient : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image ingImage;
    public Canvas canvas;

    [HideInInspector] public IngredientBase ingredientBase;
    [HideInInspector] public Transform parentAfterDrag;

    public void InitializeIngredient(IngredientBase newIngredient)
    {
        canvas = InventoryManager.Instance.canvas;
        ingredientBase = newIngredient;
        ingImage.sprite = newIngredient.ingSprite;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ingImage.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(canvas.transform);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ingImage.raycastTarget = true;

        if (eventData.pointerEnter == null || eventData.pointerEnter.GetComponent<InventorySlot>() == null)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.SetParent(parentAfterDrag);
        }
    }

    public void StartDragOnSpawn()
    {
        parentAfterDrag = null;
        OnBeginDrag(new PointerEventData(EventSystem.current));
    }
}
