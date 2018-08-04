using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell {

    // TODO : Instead some sort of spellContainer

    private static int maxSpells = 100;
    private static int globalSpellID = 0;
    public static Spell[] SPELLS = new Spell[maxSpells];

    public static Spell Flipendo = new SpellFlipendo();
    public static Spell Protego = new SpellProtego();
    public static Spell Wingardium_Leviosa = new SpellWingardiumLeviosa();
    public static Spell Depulso = new SpellDepulso();
    public static Spell Accio = new SpellAccio();
    public static Spell Lumos = new SpellLumos();
    public static Spell Nox = new SpellNox();

    public GameWorld gameWorld;

    public int spellID;
    public string name;
    public string description;

    public bool projectile = true;

    public SpellDetectionPattern detectionPattern;
    public virtual bool CanHold { get; protected set; }
    public virtual Color HoldColor { get; protected set; }

    public Spell()
    {
        gameWorld = GameObject.Find("GameWorld").GetComponent<GameWorld>();
        spellID = globalSpellID;
        SPELLS[spellID] = this;
        globalSpellID++;
        SetDetectionPattern();
    }

    public virtual void CastSpell(Wand wand)
    {
        PlayIncantation(wand);
    }

    public void PlayIncantation(Wand wand)
    {
        if (wand.owner == null) return;
        wand.owner.PlayIncantation(spellID);
    }

    public virtual void SetDetectionPattern() {}

    public bool IsSpell(int spellID)
    {
        return SPELLS[spellID] == this;
    }

    public bool IsSpell(Spell spell)
    {
        return Equals(spell);
    }

    public static Spell GetSpellFromID(int spellID)
    {
        return SPELLS[spellID];
    }

    // Use this for initialization
    /*public void Start () {
        spawnTime = Time.time;
        posStart = transform.position;
        lastDespawnCheck = Time.time;
    }*/

    // Update is called once per frame
    /*void Update () {
        
    }*/
}
