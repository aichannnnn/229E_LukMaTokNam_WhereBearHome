using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class DialogueSensor : MonoBehaviour
{

    GameManager gameManager;

    public float displayDuration = 1f;
    public float timeStarted;
    private bool isDialogueActive = false;
    public string messageKey;
    private Dictionary<string, string> messages;

    private void Start()
    {
        messages = new Dictionary<string, string>()
        {
            {"Muk", "Real bad! I don't know how to swim!"},
            {"O", "OMG how i do this"},
        };
    }
    
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        if (isDialogueActive)
        {
            if (Time.time - timeStarted > displayDuration)
            {
                isDialogueActive = false;
                gameManager.dialogueScreen.SetActive(false);
                Destroy(this.gameObject);
            }
            if (Time.time - timeStarted > displayDuration && gameObject.CompareTag("Pushalble"))
            {
                isDialogueActive = false;
                gameManager.pushScreen.SetActive(false);
                Destroy(this.gameObject);
            }
        }
    }

    public void destoryDialogue()
    {
         isDialogueActive = false;
         gameManager.pushScreen.SetActive(false);
         Destroy(this.gameObject);      
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(gameObject.CompareTag("Muk"))
            {
                ShowDialogue("Muk");
                timeStarted = Time.time;
                isDialogueActive = true;
            }
            if(gameObject.CompareTag("1stObstracle"))
            {
                ShowDialogue("O");
                timeStarted = Time.time;
                isDialogueActive = true;
            }
            if(gameObject.CompareTag("Pushalble"))
            {
                gameManager.pushScreen.SetActive(true);
                timeStarted = Time.time;
                isDialogueActive = true;
            }
        }
    }
    public void ShowDialogue(string messageKey)
    {
        if (!isDialogueActive && messages.ContainsKey(messageKey))
        {
            gameManager.NormalDialogueText.text = messages[messageKey];
            gameManager.dialogueScreen.SetActive(true);
            isDialogueActive = true;
        }
    }
}
