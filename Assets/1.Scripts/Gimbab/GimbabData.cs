using UnityEngine;

[CreateAssetMenu(fileName = "GimbabData", menuName = "Game/GimbabData")]
public class GimbabData : ScriptableObject
{
    public GimbabName gimbabName;
    public Sprite thum;
    public int price;

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
    KoreanFishCakeGimbab,
    PorkCutletGimbab,
    BulgogiGimbab,

    Gimbab_crabstick,
    Gimbab_cucumber,
    Gimbab_crabstick_cucumber,
    Gimbab_notspinach,
    Gimbab_crabstick_notspinach,

    CheezeGimbab_doublecheeze,
    CheezeGimbab_crabstick_doublecheeze,
    CheezeGimbab_cucumber_doublecheeze,
    CheezeGimbab_crabstick_cucumber_doublecheeze,
    CheezeGimbab_notspinach_doublecheeze,
    CheezeGimbab_crabstick_notspinach_doublecheeze,
    CheezeGimbab_triplecheeze,
    CheezeGimbab_crabstick_triplecheeze,
    CheezeGimbab_cucumber_triplecheeze,
    CheezeGimbab_crabstick_cucumber_triplecheeze,
    CheezeGimbab_notspinach_triplecheeze,
    CheezeGimbab_crabstick_notspinach_triplecheeze,

    TunaGimbab_crabstick,
    

    NudeGimbab,
    NudeCheezeGimbab,
    NudeTunaGimbab,
    NudeSaladGimbab,
    NudeGimchiGimbab,
    NudeChiliPepperGimbab,
    NudeShrimpGimbab,
    NudeKoreanFishCakeGimbab,
    NudePorkCutletGimbab,
    NudeBulgogiGimbab,

    KelpGimbab,
    KelpCheezeGimbab,
    KelpTunaGimbab,
    KelpSaladGimbab,
    KelpGimchiGimbab,
    KelpChiliPepperGimbab,
    KelpShrimpGimbab,
    KelpKoreanFishCakeGimbab,
    KelpPorkCutletGimbab,
    KelpBulgogiGimbab,

    NudeKelpGimbab,
    NudeKelpCheezeGimbab,
    NudeKelpTunaGimbab,
    NudeKelpSaladGimbab,
    NudeKelpGimchiGimbab,
    NudeKelpChiliPepperGimbab,
    NudeKelpShrimpGimbab,
    NudeKelpKoreanFishCakeGimbab,
    NudeKelpPorkCutletGimbab,
    NudeKelpBulgogiGimbab,
}
