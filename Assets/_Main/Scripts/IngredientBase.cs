using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptable Objects/Ingredient")]

public class IngredientBase : ScriptableObject
{
    public Sprite ingSprite;
    public string ingName;
    public string ingDescription;
    public IngredientType ingType;
    public float cookingDuration;
    public float choppingDuration;
    public float seasoningDuration;
    public bool isCooked;
    public bool isChopped;
    public bool isSeasoned;
    public IngredientBase SeasoningApplied;
}

public enum IngredientType
{
    Vegetal,
    Carne,
    Tempero
}
