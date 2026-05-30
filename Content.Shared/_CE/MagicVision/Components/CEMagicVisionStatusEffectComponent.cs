using Content.Shared.Eye;
using Robust.Shared.GameStates;

namespace Content.Shared._CE.MagicVision;

/// <summary>
/// Allows to see magic vision trace entities
/// Use only in conjunction with <see cref="StatusEffectComponent"/>, on the status effect entity.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class CEMagicVisionStatusEffectComponent : Component
{
    /// <summary>
    /// VisionMask to see Magic Vision layer
    /// </summary>
    public const VisibilityFlags VisibilityMask = VisibilityFlags.CEMagicVision;
}
