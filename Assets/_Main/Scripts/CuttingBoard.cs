using UnityEngine;
using UnityEngine.EventSystems;

public class CuttingBoard : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedIng = eventData.pointerDrag;
    }
}
