using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDetectionPattern {

    private static double THRESHOLD_DIRECTION = 30;

    private List<SpellDetectionPoint> detectionPoints;
    private List<double> detectionDirections;
    private int nextPoint;
    private float radius;
    private bool valid;
    private bool dirty;

    public SpellDetectionPattern(float radius)
    {
        detectionPoints = new List<SpellDetectionPoint>();
        detectionDirections = new List<double>();
        this.radius = radius;
        ResetDetection();
    }

    public void AddPoint(SpellDetectionPoint detectionPoint)
    {
        detectionPoints.Add(detectionPoint);
    }

    public void AddDirection(double direction)
    {
        detectionDirections.Add(direction);
    }

    // NEW
    public bool IsDetected(List<double> points)
    {
        if (points.Count != detectionDirections.Count || detectionDirections.Count == 0) return false;

        for (int i = 0; i < detectionDirections.Count; i++)
        {
            if (!(Math.Abs(detectionDirections[i] - points[i]) <= THRESHOLD_DIRECTION || Math.Abs((detectionDirections[i] + 180) - (points[i] - 180)) <= THRESHOLD_DIRECTION || Math.Abs((detectionDirections[i] - 180) - (points[i] + 180)) <= THRESHOLD_DIRECTION))
            {
                return false;
            }
        }

        return true;
    }

    // OLD
    public bool IsDetected(float x, float y)
    {
        if (!this.valid) return false;

        bool valid = false;
        for (int i = nextPoint; i < detectionPoints.Count; i++)
        {
            bool change = detectionPoints[i].CheckRegistration(x, y, radius);
            if (change) dirty = true;
            if (!detectionPoints[i].registered)
            {
                if (!valid)
                {
                    if (i > 0)
                    {
                        detectionPoints[i-1].CheckRegistration(x, y, radius);
                        if (detectionPoints[i-1].registered)
                        {
                            return false;
                        }
                    }
                    
                    this.valid = false;
                }
                return false;
            }

            if (i < detectionPoints.Count-1) nextPoint++;
            valid = true;
        }
        
        return true;
    }

    public void ResetDetection()
    {
        nextPoint = 0;
        valid = true;
        dirty = true;

        for (int i = 0; i < detectionPoints.Count; i++)
        {
            detectionPoints[i].registered = false;
        }
    }

    public List<SpellDetectionPoint> GetPoints()
    {
        return detectionPoints;
    } 

    public float GetRadius()
    {
        return radius;
    }

    public bool IsValid()
    {
        return valid;
    }

    public int NextPoint()
    {
        return nextPoint;
    }

    public bool IsDirty()
    {
        return dirty;
    }

    public void SetDirty(bool dirty)
    {
        this.dirty = dirty;
    }
	
}
