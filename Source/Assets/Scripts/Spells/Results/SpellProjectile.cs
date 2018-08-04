using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProjectile : MonoBehaviour {

    public Vector3 posStart;
    public float lastDespawnCheck;
    public float despawnDistance = 100f;
    public float speed = 40f;
    public float damage = 22;
    public Wand caster;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * Time.deltaTime * speed;

        if (Time.time - lastDespawnCheck > 1 && Vector3.Distance(posStart, transform.position) > despawnDistance)
        {
            Destroy(gameObject);
        }
    }
}
