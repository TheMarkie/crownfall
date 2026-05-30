using Content.Shared._CE.AuraDNA;
using Content.Shared._CE.MagicVision;
using Content.Shared._CE.MagicVision.Components;
using Content.Shared.Mobs;
using Content.Shared.StatusEffectNew;
using Robust.Shared.Random;
using Robust.Shared.Utility;

namespace Content.Server._CE.AuraImprint;

/// <summary>
/// This system handles the basic mechanics of spell use, such as doAfter, event invocation, and energy spending.
/// </summary>
public sealed partial class CEAuraImprintSystem : CESharedAuraImprintSystem
{
    [Dependency] private readonly IRobustRandom _random = default!;
    [Dependency] private readonly CESharedMagicVisionSystem _vision = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<CEAuraImprintComponent, MapInitEvent>(OnMapInit);
        SubscribeLocalEvent<CEHideMagicAuraStatusEffectComponent, StatusEffectAppliedEvent>(OnShuffleStatusApplied);
        SubscribeLocalEvent<CEAuraImprintComponent, MobStateChangedEvent>(OnMobStateChanged);
    }

    private void OnShuffleStatusApplied(Entity<CEHideMagicAuraStatusEffectComponent> ent, ref StatusEffectAppliedEvent args)
    {
        ent.Comp.Imprint = GenerateAuraImprint(args.Target);
        Dirty(ent);
    }

    private void OnMapInit(Entity<CEAuraImprintComponent> ent, ref MapInitEvent args)
    {
        ent.Comp.Imprint = GenerateAuraImprint((ent.Owner, ent.Comp));
        Dirty(ent);
    }

    public string GenerateAuraImprint(Entity<CEAuraImprintComponent?> ent)
    {
        if (!Resolve(ent, ref ent.Comp))
            return string.Empty;

        var letters = new[] { "ä", "ã", "ç", "ø", "ђ", "œ", "Ї", "Ћ", "ў", "ž", "Ћ", "ö", "є", "þ"};
        var imprint = string.Empty;

        for (var i = 0; i < ent.Comp.ImprintLength; i++)
        {
            imprint += letters[_random.Next(letters.Length)];
        }

        return $"[color={ent.Comp.ImprintColor.ToHex()}]{imprint}[/color]";
    }

    private void OnMobStateChanged(Entity<CEAuraImprintComponent> ent, ref MobStateChangedEvent args)
    {
        switch (args.NewMobState)
        {
            case MobState.Critical:
            {
                _vision.SpawnMagicTrace(
                    Transform(ent).Coordinates,
                    new SpriteSpecifier.Rsi(new ResPath("_CE/Actions/Spells/misc.rsi"), "skull"),
                    Loc.GetString("ce-magic-vision-crit"),
                    TimeSpan.FromMinutes(10),
                    ent);
                break;
            }
            case MobState.Dead:
            {
                _vision.SpawnMagicTrace(
                    Transform(ent).Coordinates,
                    new SpriteSpecifier.Rsi(new ResPath("_CE/Actions/Spells/misc.rsi"), "skull_red"),
                    Loc.GetString("ce-magic-vision-dead"),
                    TimeSpan.FromMinutes(10),
                    ent);
                break;
            }
        }
    }
}
