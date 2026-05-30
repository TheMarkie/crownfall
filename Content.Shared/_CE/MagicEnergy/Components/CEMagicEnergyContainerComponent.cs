using Content.Shared.Alert;
using Content.Shared._CE.MagicEnergy.Systems;
using Content.Shared.FixedPoint;
using Robust.Shared.Prototypes;
using Robust.Shared.GameStates;

namespace Content.Shared._CE.MagicEnergy.Components;

/// <summary>
/// Allows an item to store magical energy within itself.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
[Access(typeof(CESharedMagicEnergySystem))]
public sealed partial class CEMagicEnergyContainerComponent : Component
{
    [DataField, AutoNetworkedField]
    public FixedPoint2 Energy = 0;

    [DataField, AutoNetworkedField]
    public FixedPoint2 MaxEnergy = 100;

    [DataField, AutoNetworkedField]
    public ProtoId<AlertPrototype>? MagicAlert;

    /// <summary>
    /// Does this container support unsafe energy manipulation?
    /// </summary>
    [DataField, AutoNetworkedField]
    public bool UnsafeSupport;
}
