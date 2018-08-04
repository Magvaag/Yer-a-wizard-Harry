using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Wand : NetworkBehaviour {

    public static float MOUSE_SHORT_CLICK_LENGTH = 0.2f;

    // Mouse
    private float timeMouseDown;
    private bool mouseDown;

    public Player owner;
    public GameObject tip;

    // Particle Systems
    public ParticleSystem particleSystemMagic;
    public ParticleSystem particleSystemHolding;

    // Detection
    private Animator animator;
    private SpellDetection spellDetection;

    // Spell stuff
    private Spell spellActive;
    public bool spellHolding;
    private bool spellCasting;

    public List<SpellActiveEffect> activeEffects;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        activeEffects = new List<SpellActiveEffect>();
        spellDetection = new SpellDetection(this);
    }
	
	// Update is called once per frame
	void Update () {
        if (owner != null && owner.isLocalPlayer) {
            if (Input.GetMouseButtonDown(0))
            {
                timeMouseDown = Time.time;
                mouseDown = true;
            }
            else if (Input.GetMouseButton(0))
            {
                animator.SetBool("IsCasting", true);
                spellCasting = true;

                float movementX = Input.GetAxis("Mouse X");
                float movementY = Input.GetAxis("Mouse Y");
                spellDetection.UpdateMouse(movementX, movementY);
            }
            else 
            {
                /// Mouse released
                
                if (mouseDown)
                {
                    mouseDown = false;
                    if (Time.time - timeMouseDown < MOUSE_SHORT_CLICK_LENGTH)
                    {
                        if (spellHolding)
                        {
                            ReleaseSpell();
                        }
                        else
                        {
                            foreach (SpellActiveEffect activeEffect in activeEffects)
                            {
                                if (activeEffect.releaseOnClick) activeEffect.Die();
                            }
                        }
                    }
                }

                if (spellCasting)
                {
                    spellCasting = false;
                    spellDetection.CastSpell();
                }
                animator.SetBool("IsCasting", false);
                spellCasting = false;
            }
        }

        UpdateWandTip();
        FixActiveEffectsList();
    }

    public void AddActiveEffect(SpellActiveEffect activeEffect)
    {
        activeEffects.Add(activeEffect);
    }

    public void FixActiveEffectsList()
    {
        // List the dead active effects
        List<SpellActiveEffect> removeableActiveEffects = new List<SpellActiveEffect>();
        foreach (SpellActiveEffect activeEffect in activeEffects)
            if (activeEffect.dead) removeableActiveEffects.Add(activeEffect);

        // Removes the dead active effects
        foreach (SpellActiveEffect activeEffect in removeableActiveEffects)
            activeEffects.Remove(activeEffect);
    }

    public void CastSpell(SpellConfiguration spellConfiguration)
    {
        Spell spell = Spell.SPELLS[spellConfiguration.spellID];
        HoldSpell(spell);
    }
    
    public void HoldSpell(Spell spell)
    {
        spellActive = spell;

        if (spell.CanHold)
        {
            spellHolding = true;
            UpdateWandTip();
            if (owner != null) Debug.Log("Spell Holding: " + spell.name + " - " + owner.GetComponent<NetworkBehaviour>().netId);
        }
        else
        {
            ReleaseSpell();
        }

    }

    public void ReleaseSpell()
    {
        // Update the wand tip, stops the effects if no other object is affected
        UpdateWandTip();

        // Cast spell
        spellActive.CastSpell(this);


        /*switch (holdingSpellID)
        {
            case Spell.FLIPENDO:
                CastSpellFlipendo();
                break;
            case Spell.PROTEGO:
                CastSpellProtego();
                break;
            case Spell.WINGARDIUM_LEVIOSA:
                CastSpellWingardiumLeviosa();
                break;
            case Spell.DEPULSO:
                CastSpellDepulso();
                break;
            case Spell.ACCIO:
                CastSpellAccio();
                break;
            case Spell.LUMOS:
                CastSpellLumos();
                break;
            case Spell.NOX:
                CastSpellNox();
                break;
            default:
                active_spell_id = -1;
                playAudio = false;
                break;
        }

        if (playAudio && owner != null) */
        spellHolding = false;
        spellActive = null;
    }

    public void UpdateWandTip()
    {
        if (spellHolding)
        {
            var main = particleSystemHolding.main;
            main.startColor = spellActive.HoldColor;
            particleSystemHolding.Play();
        }
        else
        {
            if (activeEffects.Count > 0)
            {
                // TODO : Average out the colors
                var main = particleSystemHolding.main;
                main.startColor = activeEffects[0].color;
                particleSystemHolding.Play();
            }
            else
            {
                particleSystemHolding.Stop();
            }
        }
    }

    /*
    private void CastSpellNox()
    {
        active_spell_id = -1;
        Destroy(tip_lumos.gameObject);
        tip_lumos = null;
    }

    private void CastSpellLumos()
    {
        if (active_spell_id == Spell.LUMOS)
        {
            CastSpellNox();
            return;
        }

        active_spell_id = Spell.LUMOS;
        tip_lumos = Instantiate(spell_lumos, tip.transform);
        //lumos.transform.SetParent(tip.transform);
        //lumos.transform.localPosition.Set(0, 0, 0);
    }

    private void CastSpellAccio()
    {

    }

    private void CastSpellDepulso()
    {
        Vector3 dir = transform.parent.parent.forward + new Vector3(0, 0.3f, 0);
        active_spell_id = -1;
        if (target != null)
        {
            target.Reset();
            target.CastDepulso(dir);
            target = null;
        }
        else
        {
            RaycastHit hit;
            Vector3 pos = transform.parent.parent.position;
            int layerMask = 1 << 8;
            if (Physics.SphereCast(pos, 1, transform.parent.parent.forward, out hit, SpellWingardiumLeviosa.MAX_DISTANCE, layerMask))
            {
                target = hit.collider.GetComponent<SpellableObject>();
                target.Reset();
                target.CastDepulso(dir);
            }
        }
    }

    private void CastSpellWingardiumLeviosa()
    {
        
    }*/
}
