using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class DialogueSensor : MonoBehaviour
{

    GameManager gameManager;

    public float displayDuration = 1f;
    public float timeStarted;
    private bool isDialogueActive = false;
    public string messageKey;
    private Dictionary<string, string> messages;

    TargetPoint targetPoint;

    private void Start()
    {
        messages = new Dictionary<string, string>()
        {
            {"Muk", "That's awful! I really don't want my shoes to get wet!"},
            {"Spike", "This little thorn looks so scary"},
            {"Goal", "Finally home! I can't wait to eat the snacks I brought!"},
        };
    }
    
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetPoint = GameObject.Find("Point").GetComponentInChildren<TargetPoint>();
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
            if (Time.time - timeStarted > displayDuration && gameObject.CompareTag("GoalLine"))
            {
                isDialogueActive = false;
                gameManager.dialogueScreen.SetActive(false);
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
                ShowDialogue("Spike");
                timeStarted = Time.time;
                isDialogueActive = true;
            }
            if(gameObject.CompareTag("Pushalble"))
            {
                gameManager.pushScreen.SetActive(true);
                timeStarted = Time.time;
                isDialogueActive = true;
            }
            if(gameObject.CompareTag("GoalLine"))
            {
                ShowDialogue("Goal");
                timeStarted = Time.time;
                isDialogueActive = true;               
            }
            if(gameObject.CompareTag("End"))
            {   
              gameManager.Victory(targetPoint.point);
            }
        }
    }

    IEnumerator ChangeScreen()
    {
        yield return new WaitForSeconds(3f);
        gameManager.EndScreen.SetActive(false);
        gameManager.CreditScreen.SetActive(true);
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
