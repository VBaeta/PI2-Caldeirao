using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject droppedIng = eventData.pointerDrag;
            DraggableIngredient draggableIngredient = droppedIng.GetComponent<DraggableIngredient>();
            draggableIngredient.parentAfterDrag = transform;
        }
        
    }
}
