using JetBrains.Annotations;
using UnityEngine;



public class InventoryManager : MonoBehaviour
{
    public IngredientBase[] allIngredients;
    public IngredientBase[] discoveredIngredients;

    public InventorySlot[] slots;
    public GameObject draggableIngredientPrefab;

    public static InventoryManager Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddIngredients(IngredientBase ingredient, IngredientType ingredientType)
    {
        for (int i = 0; i < slots.Length; i++) 
        {
            InventorySlot slot = slots[i];
            if (ingredient.ingType == ingredientType)
            {
                DraggableIngredient ingredientInSlot = slot.GetComponentInChildren<DraggableIngredient>();

                if (ingredientInSlot == null)
                {
                    SpawnNewIngredient(ingredient, slot);
                    return;
                }
            }
            
        }
    }

    void SpawnNewIngredient(IngredientBase newIngredient, InventorySlot slot)
    {
        GameObject newIngGO = Instantiate(draggableIngredientPrefab, slot.transform);
        DraggableIngredient draggableIngredient = newIngGO.GetComponent<DraggableIngredient>();
        draggableIngredient.InitializeIngredient(newIngredient);
    }

    public void ResetAllSlots()
    {
        Debug.Log("Reseting Slots");

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount == 0)
            {
                break;
            }

            Destroy(slots[i].transform.GetChild(0));
            Debug.Log($"Child Destroyed: {slots[i].transform.GetChild(0)}");
        }
    }
}
