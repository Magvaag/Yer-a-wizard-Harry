using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellShield : MonoBehaviour {
    
    public float spellLast = 2;
    public ParticleSystem ps_shield;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (ps_shield.isStopped)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        SpellProjectile projectile = collision.collider.GetComponent<SpellProjectile>();
        if (projectile != null)
        {
            Destroy(projectile.gameObject);
            // TODO : Play splash animation
            // TODO : Play break and extinguish sound (extinguish sound is on projectile break not shield break though)
            Destroy(gameObject);
        }
    }
}
