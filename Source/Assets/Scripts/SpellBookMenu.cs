using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBookMenu : MonoBehaviour {

    private Player player;
    private bool visible;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    public void ToggleOptionsMenu()
    {
        if (visible) CloseSpellBookMenu();
        else OpenSpellBookMenu();
    }

    public bool IsVisible()
    {
        return visible;
    }

    public void OpenSpellBookMenu()
    {
        visible = true;
        gameObject.SetActive(true);
        player.UnlockFirstPerson();
    }

    public void CloseSpellBookMenu()
    {
        visible = false;
        gameObject.SetActive(false);
        player.LockFirstPerson();
    }
}
