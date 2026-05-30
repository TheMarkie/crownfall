using Robust.Shared.GameStates;

namespace Content.Shared._CE.AuraDNA;

/// <summary>
/// A component that stores a “blueprint” of the aura, unique to each mind.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState, Access(typeof(CESharedAuraImprintSystem))]
public sealed partial class CEAuraImprintComponent : Component
{
    [DataField, AutoNetworkedField]
    public string Imprint = string.Empty;

    [DataField]
    public int ImprintLength = 8;

    [DataField]
    public Color ImprintColor = Color.White;
}
