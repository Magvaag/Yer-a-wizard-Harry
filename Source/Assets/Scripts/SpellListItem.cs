using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpellListItem : MonoBehaviour {
    
    public Text textName;
    public Text textDescription;
    public SpellDetectionVisualizer visualizer;
    private Wand wand;
    private Spell spell;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FindWand()
    {
        GameObject player = GameObject.Find("Player");
        wand = player.GetComponentInChildren<Wand>();
    }

    public void SetSpellID(Spell spell)
    {
        this.spell = spell;
        visualizer.spell_id = spell.spellID;
        UpdateVisuals();
    }

    public void UpdateVisuals()
    { 
        textName.text = spell.name;
        textDescription.text = spell.description;
    }
}
