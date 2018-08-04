using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDetectionPoint {

    public float x;
    public float y;
    public bool registered;
    public GameObject gameObject;

    public SpellDetectionPoint(float x, float y)
    {
        this.x = x;
        this.y = y;
        registered = false;
    }

    public bool CheckRegistration(float x, float y, float radius)
    {
        bool last = registered;
        registered = Vector2.Distance(new Vector2(this.x, this.y), new Vector2(x, y)) <= radius;
        return last == registered;
    }
	
}
