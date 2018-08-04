using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SpellDetection {
    
    public Wand wand;

    private Spell detectedSpell;

    private List<Vector2> points;
    private float lastX, lastY;
    private float currX, currY;
    private float minX, minY, maxX, maxY;
    private float pointThreshold = .5f;
    private bool isTracking = false;

    public SpellDetection(Wand wand)
    {
        this.wand = wand;
    }

    public void StartTracking()
    {
        points = new List<Vector2>();
        isTracking = true;
        lastX = 0;
        lastY = 0;
        currX = 0;
        currY = 0;
        minX = 0;
        minY = 0;
        maxX = 0;
        maxY = 0;
        ResetDetection();
    }

    public void UpdateMouse(float deltaX, float deltaY)
    {
        if (!isTracking) StartTracking();

        currX += deltaX;
        currY += deltaY;

        if (currX < minX) minX = currX;
        if (currY < minY) minY = currY;
        if (currX > maxX) maxX = currX;
        if (currY > maxY) maxY = currY;

        if (Vector2.Distance(new Vector2(currX, currY), new Vector2(lastX, lastY)) >= pointThreshold)
        {
            points.Add(new Vector2(currX, currY));
            wand.particleSystemMagic.Emit(5);
            lastX = currX;
            lastY = currY;
        }
    }

    public void CastSpell()
    {
        FindSpell();
        wand.owner.CastSpell(detectedSpell);
        isTracking = false;
    }

    public void FindSpell()
    {
        // NEW
        detectedSpell = SpellDetectionDirectional.DetectSpell(points);

        /*
        // OLD
        float size = Mathf.Max(maxX-minX, maxY-minY);

        // Loop through the possible spells
        for (int i = 0; i < Spell.detectionPatterns.Length; i++)
        {
            if (Spell.detectionPatterns[i] == null) continue;
            SpellDetectionPattern pattern = Spell.detectionPatterns[i];

            // Loop through all the points
            // Let the detector know of the boundaries of the area
            for (int j = 0; j < points.Count; j++)
            {
                Vector2 p = points[j];
                float x = (p.x - minX + (size - (maxX - minX)) / 2) / size;
                float y = (p.y - minY + (size - (maxY - minY)) / 2) / size;

                if (pattern.IsDetected(x, y))
                {
                    detectedSpellID = pattern.GetSpellID();
                }
                else if (detectedSpellID == i)
                {
                    detectedSpellID = -1;
                }
            }
        }  */
    }

    private void ResetDetection()
    {
        for (int i = 0; i < Spell.SPELLS.Length; i++)
        {
            Spell spell = Spell.SPELLS[i];
            if (spell == null) continue;

            spell.detectionPattern.ResetDetection();
        }
    }
}
