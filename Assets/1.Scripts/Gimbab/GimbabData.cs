using UnityEngine;

[CreateAssetMenu(fileName = "GimbabData", menuName = "Game/GimbabData")]
public class GimbabData : ScriptableObject
{
    public GimbabName gimbabName;
    public Sprite thum;
    public int price;
    public bool isNude;
    public bool isKelp;

    public IngredientName[] ingredientNames;
}


public enum GimbabName
{
    Gimbab,
    CheezeGimbab,
    TunaGimbab,
    SaladGimbab,
    GimchiGimbab,
    ChiliPepperGimbab,
    ShrimpGimbab,
    PorkCutletGimbab,
    KoreanFishCakeGimbab,
    BulgogiGimbab
}
