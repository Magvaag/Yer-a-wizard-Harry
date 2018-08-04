using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProtego : Spell {
    
    public SpellProtego()
    {
        name = "Protego";
        description = "Creates a shield.";
    }

    public override void CastSpell(Wand wand)
    {
        base.CastSpell(wand);

        GameObject go_spell = Object.Instantiate(gameWorld.prefabProtegoShield, wand.transform.parent.parent.position, Quaternion.identity);
        go_spell.transform.rotation = wand.transform.parent.rotation;
        go_spell.GetComponent<AudioSource>().Play();
    }

    public override void SetDetectionPattern()
    {
        detectionPattern = new SpellDetectionPattern(0.15f);

        // Point-based detection
        detectionPattern.AddPoint(new SpellDetectionPoint(.5f, .95f));
        detectionPattern.AddPoint(new SpellDetectionPoint(.5f, .85f));
        detectionPattern.AddPoint(new SpellDetectionPoint(.5f, .75f));
        detectionPattern.AddPoint(new SpellDetectionPoint(.5f, .65f));
        detectionPattern.AddPoint(new SpellDetectionPoint(.5f, .55f));
        detectionPattern.AddPoint(new SpellDetectionPoint(.5f, .45f));
        detectionPattern.AddPoint(new SpellDetectionPoint(.5f, .35f));
        detectionPattern.AddPoint(new SpellDetectionPoint(.5f, .25f));
        detectionPattern.AddPoint(new SpellDetectionPoint(.5f, .15f));
        detectionPattern.AddPoint(new SpellDetectionPoint(.5f, .05f));
        
        // Angle-based detection
        detectionPattern.AddDirection(180);
    }
    
}
