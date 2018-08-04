using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellActiveEffectFloat : SpellActiveEffect {

    public SpellableObject target;
    public Wand caster;
    public Spell spell;

    // Distance to keep to the owner
    // TODO : Scroll to change distance?
    private float preferredDistance;
    private float movementSpeed = 15;
    private float rotationYStart;

    public SpellActiveEffectFloat(SpellableObject target, Wand caster, Spell spell)
    {
        this.target = target;
        this.caster = caster;
        this.spell = spell;
        releaseOnClick = true;
        color = new Color(.4f, .4f, 1);

        OnEffectCreated();
    }

    public override void Update()
    {
        UpdateFloating();
    }

    public void UpdateFloating()
    {
        Vector3 preferredPoint = caster.transform.position + caster.transform.parent.parent.forward * preferredDistance;
        float speedModifier = Vector3.Distance(preferredPoint, target.transform.position);

        float speedThreshold = 2;
        if (speedModifier > speedThreshold) speedModifier = 1;
        else speedModifier = speedModifier / speedThreshold;

        float minSpeed = 0.05f;
        if (speedModifier < minSpeed) speedModifier = minSpeed;

        float step = movementSpeed * Time.deltaTime * speedModifier;
        target.transform.position = Vector3.MoveTowards(target.transform.position, preferredPoint, step);

        Vector3 preferredRotation = caster.owner.transform.rotation.eulerAngles;
        preferredRotation.y += rotationYStart;
        target.transform.rotation = Quaternion.Euler(target.transform.rotation.eulerAngles.x, preferredRotation.y, target.transform.rotation.eulerAngles.z);
    }

    public override void OnEffectCreated()
    {
        base.OnEffectCreated();

        preferredDistance = Vector3.Distance(target.transform.position, caster.owner.transform.position);
        rotationYStart = caster.owner.transform.rotation.eulerAngles.y;

        Rigidbody rigidbody = target.GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        rigidbody.freezeRotation = true;

        target.GetComponentInChildren<ParticleSystem>().Play();
        target.AddActiveEffect(this);
    }

    public override void Die()
    {
        base.Die();

        Rigidbody rigidbody = target.GetComponent<Rigidbody>();
        rigidbody.useGravity = true;
        rigidbody.freezeRotation = false;

        target.GetComponentInChildren<ParticleSystem>().Stop();
    }

}
