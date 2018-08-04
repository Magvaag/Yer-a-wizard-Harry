using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpellDetectionDirectional {

    private static bool PRINT_ANGLE = false;
    private static double DIRECTION_THRESHOLD = 30;

    // TODO : Might want to disclude the first few points, as the angle changes more the smaller area we check
    // TODO : Might want to constantly check only the angle of the last e.g. 5, as the longer you drag the mouse, the longer you have to drag it out again, which might skew results. Needs to be tested first!
    public static Spell DetectSpell(List<Vector2> points)
    {
        if (PRINT_ANGLE) Debug.Log("=== Detect Spell === (" + points.Count + ")");
        List<double> angles = CalculateAngles(points);

        for (int i = 0; i < Spell.SPELLS.Length; i++)
        {
            Spell spell = Spell.SPELLS[i];
            if (spell == null) continue;
            
            if (spell.detectionPattern.IsDetected(angles))
            {
                return spell;
            }
        }

        return null;
    }

    private static List<double> CalculateAngles(List<Vector2> points)
    {
        List<double> directions = new List<double>();
        Vector2 lastPoint = new Vector2(0, 0);

        double minAngle = -1;
        double maxAngle = -1;
        double totalAngle = 0; // So we can average the total angle instead of the extremities. 
        double pointsAnalysed = 0;

        // If the angle loops around from 360 to 0, this should aim to keep it at safe angles
        double flag = 0; // If the first angle is between 90 and 270, this stays at 0, else this is 180
        bool first = true;

        for (int i = 0; i < points.Count; i++)
        {
            // Skip the first 5? Because of sensitivity
            if (i < 3) continue;

            // Get the angle
            Vector2 point = points[i];
            double angle = (GetAngleFromPoint(point, lastPoint) + 360) % 360;
            if (first && (angle <= 90 || angle >= 270))
                flag = 180;

            // Make sure we keep the angles safe
            angle += flag + 360;
            angle %= 360;

            // Set the min/max angles
            if (minAngle < 0 || angle < minAngle) minAngle = angle;
            if (maxAngle < 0 || angle > maxAngle) maxAngle = angle;

            totalAngle += angle;
            pointsAnalysed++;

            // Reset first
            first = false;

            // Check if angle escapes direction (?), or if this is the last point
            if (maxAngle - minAngle >= DIRECTION_THRESHOLD || i == points.Count - 1)
            {
                // Save the direction
                double realAngle = (totalAngle / pointsAnalysed - flag + 360) % 360;
                directions.Add(realAngle);
                lastPoint = point;

                if (PRINT_ANGLE) Debug.Log("ANGLE: " + realAngle + " - " + maxAngle + ", " + minAngle);

                // Reset
                flag = 0;
                first = true;
                minAngle = -1;
                maxAngle = -1;
                totalAngle = 0;
                pointsAnalysed = 0;
            }
        }

        return directions;
    }

    private static double GetAngleFromPoint(Vector2 point, Vector2 center)
    {
        double dy = (point.y - center.y);
        double dx = (point.x - center.x);

        double theta = Math.Atan2(dy, dx);
        double angle = (90 - ((theta * 180) / Math.PI)) % 360;

        return angle;
    }

}
