using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image ingredientImage;
    public GameObject ingredientGO;

    [HideInInspector] public IngredientBase currentIngredient;

    public void SetIngredient(IngredientBase ingredient)
    {
        currentIngredient = ingredient;

        if (ingredient != null)
        {
            ingredientGO.SetActive(true);
            ingredientImage.sprite = ingredient.ingSprite;
        }
        else
        {
            ingredientGO.SetActive(false);
            ingredientImage.sprite = null;
        }
    }

    public void OnClick()
    {
        if (currentIngredient != null)
        {
            GameObject newIngredient = Instantiate(InventoryManager.Instance.draggableIngredientPrefab, InventoryManager.Instance.canvas.transform);
            DraggableIngredient drag = newIngredient.GetComponent<DraggableIngredient>();
            drag.InitializeIngredient(currentIngredient);
            drag.StartDragOnSpawn();
        }
    }

    public bool IsEmpty()
    {
        return currentIngredient == null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        DraggableIngredient dropped = eventData.pointerDrag.GetComponent<DraggableIngredient>();

        if (dropped != null)
        {
            SetIngredient(dropped.ingredientBase);
            Destroy(dropped.gameObject);
        }
    }
}
