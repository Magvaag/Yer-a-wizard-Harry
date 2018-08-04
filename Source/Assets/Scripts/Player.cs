using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : NetworkBehaviour {

    float maxStamina = 100;
    float stamina;

    public GameWorld gameWorld;
    public GameObject body;
    public Wand wand;

    // Disable components
    public Behaviour[] disabableComponents;

    public AudioSource incatationAudioSource;
    public AudioSource hurtAudioSource;
    public List<AudioClip> incantations;
    public List<AudioClip> hurtSounds;

    // Use this for initialization
    void Start () {
        //stamina = maxStamina;
        //UpdateHealthFiller();

        gameWorld = GameObject.Find("GameWorld").GetComponent<GameWorld>();

        // If this is not local, disable some duplicate components
        if (!isLocalPlayer)
        {
            foreach (Behaviour behaviour in disabableComponents)
                behaviour.enabled = false;
        }
        else
        {
            // Disable the main camera
            gameWorld.cameraScene.gameObject.SetActive(false);

            // Disable the body
            body.SetActive(false);

            gameWorld.menuOptions.SetPlayer(this);
            gameWorld.menuSpellBook.SetPlayer(this);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameWorld.chat.isChatting)
            {
                // Close the chat
                gameWorld.chat.CloseChat();
                LockFirstPerson();
            }
            else
            {
                if (gameWorld.menuSpellBook.IsVisible())
                {
                    // Close the spell book
                    gameWorld.menuSpellBook.CloseSpellBookMenu();
                    gameWorld.menuOptions.OpenOptionsMenu();
                }
                else
                {
                    // Toggle the options menu
                    gameWorld.menuOptions.ToggleOptionsMenu();
                }
            }
        }

        // Open chat!
        if (Input.GetKeyDown(KeyCode.T) && !gameWorld.chat.isChatting)
        {
            gameWorld.chat.OpenChat();
            UnlockFirstPerson();
        }
    }

    public void CastSpell(Spell spell)
    {
        Debug.Log("Yesss!");
        if (spell == null) return;

        // Create Spell Configuration
        SpellConfiguration spellCfg = new SpellConfiguration();
        spellCfg.spellID = spell.spellID;

        CmdCastSpell(spellCfg);
    }

    [Command]
    public void CmdCastSpell(SpellConfiguration spellCfg)
    {
        if (wand == null) return;
        wand.CastSpell(spellCfg);
    }

    public void LockFirstPerson()
    {
        bool toggle = false;
        GetComponent<FirstPersonController>().detectSpells = toggle;
        GetComponent<FirstPersonController>().m_MouseLook.lockCursor = !toggle;
        Cursor.visible = toggle;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void UnlockFirstPerson()
    {
        bool toggle = true;
        GetComponent<FirstPersonController>().detectSpells = toggle;
        GetComponent<FirstPersonController>().m_MouseLook.lockCursor = !toggle;
        Cursor.visible = toggle;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void PlayIncantation(int spell_id)
    {
        incatationAudioSource.clip = incantations[spell_id];
        incatationAudioSource.Play();
    }

    public void PlayHurtSound()
    {
        System.Random random = new System.Random();
        int r = random.Next(hurtSounds.Count);
        hurtAudioSource.clip = hurtSounds[r];
        hurtAudioSource.Play();
    }

    public void ChangeHealth(float deltaStamina)
    {
        stamina += deltaStamina;
        if (deltaStamina < 0) PlayHurtSound();
        UpdateHealthFiller();
    }

    void UpdateHealthFiller()
    {
        float fillAmount = stamina / maxStamina;
        if (fillAmount < 0) fillAmount = 0;
        if (fillAmount > 1) fillAmount = 1;
        //gameWorld.filler.fillAmount = fillAmount;
    }
}
