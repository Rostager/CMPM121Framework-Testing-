using UnityEngine;
using System.Collections;

// TestSpell2: Quick Shot — fires rapidly with low mana cost but deals little damage.
public class TestSpell2 : Spell
{
    public TestSpell2(SpellCaster owner) : base(owner) { }

    public override string GetName()
    {
        return "Quick Shot";
    }

    public override int GetManaCost()
    {
        return 5;
    }

    public override int GetDamage()
    {
        return 40;
    }

    public override float GetCooldown()
    {
        return 0.3f;
    }

    public override int GetIcon()
    {
        return 2;
    }
}
