using UnityEngine;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;


public class SpellBuilder 
{

    public Spell Build(SpellCaster owner)
    {
        return new Spell(owner);
    }

    // Returns a random spell chosen from the full pool of available spell types.
    public static Spell GetRandomSpell(SpellCaster owner)
    {
        int pick = UnityEngine.Random.Range(0, 3);
        switch (pick)
        {
            case 0: return new Spell(owner);
            case 1: return new TestSpell1(owner);
            case 2: return new TestSpell2(owner);
            default: return new Spell(owner);
        }
    }

    public SpellBuilder()
    {        
    }

}
