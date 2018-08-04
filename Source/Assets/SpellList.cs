using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellList : MonoBehaviour {
    
    public SpellListItem prefab_listItem;
    private List<SpellListItem> listItems;

    // Use this for initialization
    void Start()
    {
        int spells;

        listItems = new List<SpellListItem>();
        // Count spells
        for (int i = 0; i < Spell.SPELLS.Length; i++)
        {
            if (Spell.SPELLS[i] == null)
            {
                spells = i;
                break;
            }
            else
            {
                // Generate an item for the spell
                SpellListItem item = Instantiate(prefab_listItem, transform);
                item.FindWand();
                item.SetSpellID(Spell.SPELLS[i]);
                listItems.Add(item);
            }

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateVisuals()
    {
        for (int i = 0; i < listItems.Count; i++)
        {
            listItems[i].UpdateVisuals();
        }
    }
}
