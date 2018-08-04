using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellActiveEffect {

    public bool dead = false;
    public Color color; // The wand color to display of the effect
    public bool releaseOnClick = false; // Whether the effect dies on next mouse click or not

    public SpellActiveEffect()
    {
        color = new Color(1, 1, 1);
    }

    public virtual void Update()
    {

    }

    public virtual void OnEffectCreated()
    {

    }

    public virtual void Die()
    {
        dead = true;
    }

}
