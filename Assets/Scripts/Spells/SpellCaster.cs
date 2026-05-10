using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellCaster 
{
    public int mana;
    public int max_mana;
    public int mana_reg;
    public Hittable.Team team;

    // Spell slots — supports up to maxSpells spells at once.
    public List<Spell> spells;
    public int maxSpells = 3;

    public IEnumerator ManaRegeneration()
    {
        while (true)
        {
            mana += mana_reg;
            mana = Mathf.Min(mana, max_mana);
            yield return new WaitForSeconds(1);
        }
    }

    public SpellCaster(int mana, int mana_reg, Hittable.Team team)
    {
        this.mana = mana;
        this.max_mana = mana;
        this.mana_reg = mana_reg;
        this.team = team;
        spells = new List<Spell>();
        spells.Add(new SpellBuilder().Build(this));
    }

    // Adds a spell if there is room in the spell slots.
    public bool AddSpell(Spell s)
    {
        if (spells.Count >= maxSpells) return false;
        spells.Add(s);
        return true;
    }

    // Removes the spell at the given index (no-op if index is out of range).
    public void RemoveSpell(int index)
    {
        if (index < 0 || index >= spells.Count) return;
        spells.RemoveAt(index);
    }

    // Casts the first ready spell that the player has enough mana for.
    public IEnumerator Cast(Vector3 where, Vector3 target)
    {
        foreach (Spell spell in spells)
        {
            if (mana >= spell.GetManaCost() && spell.IsReady())
            {
                mana -= spell.GetManaCost();
                yield return spell.Cast(where, target, team);
                yield break;
            }
        }
        yield break;
    }

    // Casts the spell at a specific slot index (for direct player input).
    public IEnumerator Cast(Vector3 where, Vector3 target, int index)
    {
        if (index < 0 || index >= spells.Count) yield break;
        Spell spell = spells[index];
        if (mana >= spell.GetManaCost() && spell.IsReady())
        {
            mana -= spell.GetManaCost();
            yield return spell.Cast(where, target, team);
        }
        yield break;
    }

}
