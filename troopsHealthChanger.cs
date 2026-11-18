using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

[HarmonyPatch(typeof(DefaultCharacterStatsModel), "MaxHitpoints")]
public static class SetTroopHealth
{
    public static void Postfix(CharacterObject character, ref ExplainedNumber __result)
    {
        if (character == null) return;

        if (character.StringId == "looter")
        {
            float customHealth = 150f;
            __result = new ExplainedNumber(customHealth, false, null);
        }


    }
}
