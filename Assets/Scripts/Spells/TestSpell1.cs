using UnityEngine;
using System.Collections;

// TestSpell1: Heavy Bolt — deals high damage but costs more mana and has a slow cooldown.
public class TestSpell1 : Spell
{
    public TestSpell1(SpellCaster owner) : base(owner) { }

    public override string GetName()
    {
        return "Heavy Bolt";
    }

    public override int GetManaCost()
    {
        return 25;
    }

    public override int GetDamage()
    {
        return 250;
    }

    public override float GetCooldown()
    {
        return 1.5f;
    }

    public override int GetIcon()
    {
        return 1;
    }
}
