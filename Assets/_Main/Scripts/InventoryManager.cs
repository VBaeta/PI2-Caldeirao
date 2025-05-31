using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public IngredientBase[] allIngredients;
    public IngredientBase[] discoveredIngredients;

    public InventorySlot[] slots;
    public GameObject draggableIngredientPrefab;
    public Image inventoryBackground;
    public Canvas canvas;

    public static InventoryManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void AddIngredient(IngredientBase ingredient, IngredientType ingredientType)
    {
        if (ingredient.ingType != ingredientType)
            return;

        for (int i = 0; i < slots.Length; i++)
        {
            InventorySlot slot = slots[i];
            if (slot.IsEmpty())
            {
                slot.SetIngredient(ingredient);
                return;
            }
        }
    }


    public void ResetAllSlots()
    {
        foreach (InventorySlot slot in slots)
        {
            slot.SetIngredient(null);
        }
    }
}
