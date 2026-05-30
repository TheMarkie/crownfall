using Content.Shared._CE.AuraDNA;
using Content.Shared.StatusEffectNew.Components;
using Robust.Shared.GameStates;

namespace Content.Shared._CE.MagicVision.Components;

/// <summary>
/// Makes you leave random imprints of magical aura instead of the original
/// Use only in conjunction with <see cref="StatusEffectComponent"/>, on the status effect entity.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState, Access(typeof(CESharedAuraImprintSystem))]
public sealed partial class CEHideMagicAuraStatusEffectComponent : Component
{
    [DataField, AutoNetworkedField]
    public string Imprint = string.Empty;
}
