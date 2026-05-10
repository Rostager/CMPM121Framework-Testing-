using UnityEngine;

public class SpellUIContainer : MonoBehaviour
{
    public GameObject[] spellUIs;
    public PlayerController player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // we only have one spell (right now)
        spellUIs[0].SetActive(true);
        for(int i = 1; i< spellUIs.Length; ++i)
        {
            spellUIs[i].SetActive(false);
        }
    }

    // Activates a SpellUI slot for each spell currently in the caster's list
    // and sets the displayed spell. Call this after the spellcaster is ready.
    public void RefreshUI()
    {
        if (player == null || player.spellcaster == null) return;
        var spells = player.spellcaster.spells;
        for (int i = 0; i < spellUIs.Length; i++)
        {
            bool hasSpell = i < spells.Count;
            spellUIs[i].SetActive(hasSpell);
            if (hasSpell)
            {
                var ui = spellUIs[i].GetComponent<SpellUI>();
                if (ui != null) ui.SetSpell(spells[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
