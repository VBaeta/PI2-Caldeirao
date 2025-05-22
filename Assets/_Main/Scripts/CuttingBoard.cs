using UnityEngine;
using UnityEngine.EventSystems;

public class CuttingBoard : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject droppedIng = eventData.pointerDrag;
            DraggableIngredient draggableIngredient = droppedIng.GetComponent<DraggableIngredient>();
            draggableIngredient.parentAfterDrag = transform;
            DetectIngredient();
        }

    }

    public void DetectIngredient()
    {
        
            Debug.Log("na tábua");
            //Start Timer
            //Show Time On Screen
            //Modify Ingredient to Chopped = true.
        
    }

}
