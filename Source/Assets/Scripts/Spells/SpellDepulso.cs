using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDepulso : Spell {
    
    private float depulsoForce = 15;

    public SpellDepulso()
    {
        name = "Depulso";
        description = "Pushes objects away.";
        CanHold = true;
        HoldColor = new Color(.3f, .3f, .3f);
    }

    public override void CastSpell(Wand wand)
    {
        Vector3 dir = wand.transform.parent.parent.forward + new Vector3(0, 0.3f, 0);

        bool foundTargets = false;
        foreach (SpellActiveEffect activeEffect in wand.activeEffects)
        {
            if (activeEffect is SpellActiveEffectFloat)
            {
                activeEffect.Die();
                CastDepulso(((SpellActiveEffectFloat) activeEffect).target, dir);
                foundTargets = true;
            }
        }

        if (!foundTargets)
        {
            Vector3 pos = wand.transform.parent.parent.position;
            int layerMask = 1 << 8;
            RaycastHit[] hits = Physics.SphereCastAll(pos, 1, wand.transform.parent.parent.forward, SpellWingardiumLeviosa.MAX_DISTANCE, layerMask);
            foreach (RaycastHit hit in hits)
            {
                SpellableObject target = hit.collider.GetComponent<SpellableObject>();
                CastDepulso(target, dir);
            }
        }
    }

    public void CastDepulso(SpellableObject spellableObject, Vector3 direction)
    {
        Rigidbody rigidbody = spellableObject.GetComponent<Rigidbody>();
        rigidbody.velocity += direction * depulsoForce;
    }

    public override void SetDetectionPattern()
    {
        detectionPattern = new SpellDetectionPattern(0.2f);
        detectionPattern.AddPoint(new SpellDetectionPoint(35 / 40f, 30 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(33 / 40f, 26 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(32 / 40f, 22 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(34 / 40f, 18 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(37 / 40f, 15 / 40f));

        // Angle-based detection
        detectionPattern.AddDirection(90);
    }

    /*
     * 
     * 
     * */
}
