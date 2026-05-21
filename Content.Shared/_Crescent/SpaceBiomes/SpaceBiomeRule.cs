using Content.Shared._Crescent.SpaceBiomes;

namespace Content.Shared.Random.Rules;

public sealed partial class InSpaceBiomeRule : RulesRule
{
    [DataField]
    public string Biome;

    public override bool Check(EntityManager entManager, EntityUid uid)
    {
        if (entManager.TryGetComponent(uid, out SpaceBiomeTrackerComponent? tracker) && tracker.Biome == Biome)
        {
            return !Inverted;
        }

        return Inverted;
    }
}
