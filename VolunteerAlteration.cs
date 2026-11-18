using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;


[HarmonyPatch(typeof(DefaultVolunteerModel), "GetBasicVolunteer")]
public class VolunteerAlteration
{
    [HarmonyPostfix]
    public static void Postfix(Hero sellerHero,ref CharacterObject __result)
    {
        CharacterObject troopToSubstitute = CharacterObject.Find("battanian_horseman");
        var settings = ModSettings.Instance;
        
        __result = sellerHero.Culture.BasicTroop;
        
        if (sellerHero.CurrentSettlement.IsVillage)
        {
            if (MBRandom.RandomFloat < (settings.SpawnRatio/2))
            {
                __result = troopToSubstitute;
            }
            else
            {
                __result = sellerHero.Culture.BasicTroop;
            }
        }

        if (sellerHero.IsRuralNotable && sellerHero.CurrentSettlement.Village.Bound.IsCastle)
        {
            if (MBRandom.RandomFloat < settings.SpawnRatio && sellerHero.CurrentSettlement.IsVillage && sellerHero.CurrentSettlement.Village.VillageType.StringId.Contains("_horse_ranch"))
            {
                __result = troopToSubstitute;
            }

            else 
            {
                __result = sellerHero.Culture.EliteBasicTroop; 
            }
        }



    }

}