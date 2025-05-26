using UnityEngine;

public class Freezer : MonoBehaviour
{
   public IngredientType storageType;

   public void OnClick()
    {
        InventoryManager.Instance.ResetAllSlots();

        for (int i = 0; i < InventoryManager.Instance.discoveredIngredients.Length; i++)
        {
            InventoryManager.Instance.AddIngredients(InventoryManager.Instance.discoveredIngredients[i], storageType);
        }
    }
}
