using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFlipendo : Spell {

    public int damage;

    public SpellFlipendo()
    {
        damage = 22;
        name = "Flipendo";
        description = "Knockback jinx. Blast apart fragile objects.";
        CanHold = true;
        HoldColor = new Color(1, .4f, 0);
    }

    public override void CastSpell(Wand wand)
    {
        base.CastSpell(wand);

        GameObject spell = Object.Instantiate(gameWorld.prefabProjectileFlipendo, wand.transform.parent.parent.position, Quaternion.identity);
        spell.transform.rotation = wand.transform.parent.rotation;
        spell.transform.position += spell.transform.forward;
        spell.GetComponent<SpellProjectile>().damage = damage;
        spell.GetComponent<SpellProjectile>().caster = wand;
        spell.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    /*void Update () {
        
    }*/

    public override void SetDetectionPattern()
    {
        detectionPattern = new SpellDetectionPattern(0.2f);
        detectionPattern.AddPoint(new SpellDetectionPoint(4/40f, 21/40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(8 / 40f, 18 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(11 / 40f, 15 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(14/40f, 12/40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(16 / 40f, 16 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(18 / 40f, 21 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(20 / 40f, 24 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(22 / 40f, 28 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(26 / 40f, 30 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(30 / 40f, 26 / 40f));
        detectionPattern.AddPoint(new SpellDetectionPoint(36/40f, 29/40f));

        // Angle-based detection
        detectionPattern.AddDirection(155);
        detectionPattern.AddDirection(25);
        detectionPattern.AddDirection(90);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (hasDealtDamage) return;


        Player player = collision.collider.GetComponent<Player>();
        if (caster == null || player != caster)
        {
            // Hurt enemy player
            if (player != null)
            {
                player.ChangeHealth(-damage);
                hasDealtDamage = true;
            }
            Destroy(gameObject);
        }
    }*/
}
