using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellWingardiumLeviosa : Spell {

    public static float MAX_DISTANCE = 20.0f;

    public SpellWingardiumLeviosa()
    {
        name = "Wingardium Leviosa";
        description = "Makes objects fly.";

        CanHold = true;
        HoldColor = new Color(0, .2f, 1);
    }

    public override void CastSpell(Wand wand)
    {
        base.CastSpell(wand);
        float RADIUS = 2;

        RaycastHit hit;
        Vector3 pos = wand.transform.parent.parent.position;
        int layerMask = 1 << 8;
        if (Physics.SphereCast(pos, RADIUS, wand.transform.parent.parent.forward, out hit, MAX_DISTANCE, layerMask))
        {
            SpellActiveEffectFloat activeEffect = new SpellActiveEffectFloat(hit.collider.GetComponent<SpellableObject>(), wand, Wingardium_Leviosa);
            wand.AddActiveEffect(activeEffect);
        }
    }

    public override void SetDetectionPattern()
    {
        detectionPattern = new SpellDetectionPattern(0.2f);
        detectionPattern.AddPoint(new SpellDetectionPoint(35 / 40f, 30 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(33 / 40f, 26 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(32 / 40f, 22 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(34 / 40f, 18 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(37 / 40f, 15 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(39 / 40f, 14 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(36 / 40f, 12 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(30 / 40f, 12 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(26 / 40f, 14 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(21 / 40f, 16 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(16 / 40f, 18 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(12 / 40f, 19 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(7 / 40f, 21 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(4 / 40f, 20 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(3 / 40f, 17 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(4 / 40f, 14 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(8 / 40f, 11 / 40f));

        // Angle-based detection
        detectionPattern.AddDirection(315);
        detectionPattern.AddDirection(90);
        detectionPattern.AddDirection(0);
    }

}
