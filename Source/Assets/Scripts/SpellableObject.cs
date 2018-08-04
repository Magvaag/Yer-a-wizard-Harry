using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellableObject : MonoBehaviour {

    // Effects active on this object
    private List<SpellActiveEffect> activeEffects;

	// Use this for initialization
	void Start () {
        activeEffects = new List<SpellActiveEffect>();
    }
	
	// Update is called once per frame
	void Update () {
        List<SpellActiveEffect> removeableActiveEffects = new List<SpellActiveEffect>();
		foreach (SpellActiveEffect activeEffect in activeEffects)
        {
            if (activeEffect.dead)
            {
                removeableActiveEffects.Add(activeEffect);
                continue;
            }
            activeEffect.Update();
        }

        // Removes the dead active effects
        foreach (SpellActiveEffect activeEffect in removeableActiveEffects)
        {
            activeEffects.Remove(activeEffect);
        }
	}

    public void AddActiveEffect(SpellActiveEffect activeEffect)
    {
        activeEffects.Add(activeEffect);
    }
}
