using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v1;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

internal sealed class ModSettings : AttributeGlobalSettings<ModSettings> 
{

    public override string Id => "spawn_settings";
    public override string DisplayName => "Spawn chance for special units";
    public override string FolderName => "MCM";
    public override string FormatType => "json";

    [SettingPropertyFloatingInteger("Spawn Chance", 0f, 1f, "#0%",Order = 2,RequireRestart = false, HintText = "Spawn chances for special units.")]
    [SettingPropertyGroup("Genral")]
    public float SpawnRatio { get; set; } = 0.1f;
    


}