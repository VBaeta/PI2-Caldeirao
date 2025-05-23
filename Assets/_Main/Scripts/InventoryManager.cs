using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public IngredientBase[] ingredients;

    public DraggableIngredient[] draggableIngredients;



    public void PopulateInventory()
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            if (ingredients[i].ingType == IngredientType.Vegetal)
            {
                Debug.Log(ingredients[i].name);
                draggableIngredients[i].ingInfo = ingredients[i];
                draggableIngredients[i].InitializeIngredient();
            }

            else
            {
                Debug.Log(ingredients[i].ingType);
            }
            
        }
    }

    public void Clicar()
    {
        PopulateInventory();
    }
}
