using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public IngredientBase ingredient;
    public Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SpawnIngredientCopy);
    }

    void SpawnIngredientCopy()
    {
        GameObject newIngredient = Instantiate(InventoryManager.Instance.draggableIngredientPrefab, InventoryManager.Instance.canvas.transform);
        DraggableIngredient draggable = newIngredient.GetComponent<DraggableIngredient>();
        draggable.InitializeIngredient(ingredient);

        draggable.StartDragOnSpawn();
    }
}
