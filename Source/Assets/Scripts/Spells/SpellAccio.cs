using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAccio : Spell {

    public SpellAccio()
    {
        name = "Accio";
        description = "Draws objects to you.";
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

        // Angle-based detection
        detectionPattern.AddDirection(45);
        detectionPattern.AddDirection(135);
    }
}
