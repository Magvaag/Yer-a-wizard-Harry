using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellLumos : Spell {

    public SpellLumos()
    {
        name = "Lumos";
        description = "Light-creation spell.";
    }

    public override void SetDetectionPattern()
    {
        detectionPattern = new SpellDetectionPattern(0.2f);
        detectionPattern.AddPoint(new SpellDetectionPoint(.95f, .5f));
        detectionPattern.AddPoint(new SpellDetectionPoint(.85f, .5f));
        detectionPattern.AddPoint(new SpellDetectionPoint(.75f, .5f));
        detectionPattern.AddPoint(new SpellDetectionPoint(.65f, .5f));
        detectionPattern.AddPoint(new SpellDetectionPoint(.55f, .5f));
        detectionPattern.AddPoint(new SpellDetectionPoint(.45f, .5f));
        detectionPattern.AddPoint(new SpellDetectionPoint(.35f, .5f));
        detectionPattern.AddPoint(new SpellDetectionPoint(.25f, .5f));
        detectionPattern.AddPoint(new SpellDetectionPoint(.15f, .5f));
        detectionPattern.AddPoint(new SpellDetectionPoint(.05f, .5f));

        /*detectionPattern.AddPoint(new SpellDetectionPoint(2 / 40f, 10 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(6 / 40f, 10 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(13 / 40f, 10 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(19 / 40f, 12 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(23 / 40f, 15 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(26 / 40f, 18 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(27 / 40f, 23 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(27 / 40f, 27 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(24 / 40f, 30 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(19 / 40f, 32 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(14 / 40f, 31 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(12 / 40f, 28 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(12 / 40f, 24 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(12 / 40f, 29 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(14 / 40f, 16 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(17 / 40f, 13 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(20 / 40f, 12 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(23 / 40f, 11 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(27 / 40f, 10 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(32 / 40f, 9 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(37 / 40f, 9 / 40f));*/
    }

}
