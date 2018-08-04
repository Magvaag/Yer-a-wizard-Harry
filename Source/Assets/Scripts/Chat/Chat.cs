using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Chat : MonoBehaviour {

    public InputField inputField;
    public GameObject chatContentView;

    // Prefabs
    public GameObject prefabTextElement;

    // Variables
    public bool isChatting = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PostMessage()
    {
        // If the user presses escape, don't post the message
        if (Input.GetKeyDown(KeyCode.Escape)) return;

        GameObject textElement = Instantiate(prefabTextElement, Vector3.zero, Quaternion.identity, chatContentView.transform);
        textElement.GetComponent<Text>().text = inputField.text;
        inputField.text = "";

        // Keep focus
        inputField.ActivateInputField();
    }

    public void OpenChat()
    {
        isChatting = true;
        gameObject.SetActive(true);

        // Focus on input field
        inputField.ActivateInputField();
    }

    public void CloseChat()
    {
        isChatting = false;
        //gameObject.SetActive(false);
    }
}
