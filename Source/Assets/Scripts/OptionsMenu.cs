using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour {

    private Player player;
    private bool visible;

	// Use this for initialization
	void Start () {
        visible = false;
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
        if (visible) CloseOptionsMenu();
        else OpenOptionsMenu();
    }

    public bool IsVisible()
    {
        return visible;
    }

    public void OpenSpellBook()
    {
        // Close, but don't unlock
        gameObject.SetActive(false);
        player.gameWorld.menuSpellBook.OpenSpellBookMenu();
        visible = false; // Do this last, don't want the menu to stop showing
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void OpenOptionsMenu()
    {
        gameObject.SetActive(true);
        player.UnlockFirstPerson();
        visible = true;
    }

    public void CloseOptionsMenu()
    {
        gameObject.SetActive(false);
        player.LockFirstPerson();
        visible = false;
    }
}
