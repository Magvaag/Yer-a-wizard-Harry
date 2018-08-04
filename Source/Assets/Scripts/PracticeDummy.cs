using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeDummy : MonoBehaviour {

    public Wand wand;
    private float castDelay = 3;
    private float holdDelay = 10;
    private float lastCast;

	// Use this for initialization
	void Start () {
        lastCast = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		if ((Time.time - lastCast) >= castDelay)
        {
            lastCast = Time.time;
            if (wand.spellHolding) wand.ReleaseSpell();
            else
            {
                wand.HoldSpell(Spell.Flipendo);
            }
        }
    }
}
