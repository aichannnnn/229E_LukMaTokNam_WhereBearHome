using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{

    [Header("UI Elements")]

    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject dialogueScreen;
    public GameObject pushScreen;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI NormalDialogueText;
    public TextMeshProUGUI PushItemText;

    public Button restartButton;
    public Button startButton;

    DialogueSensor dialogueSensor;

    private void Awake()
    {
        Time.timeScale = 1f;
        startButton.onClick.AddListener(() => { StartGame();});
    }

    private void Start()
    {
        dialogueScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        titleScreen.SetActive(false);
    }

    void StartGame()
    {
        Time.timeScale = 1f;
        titleScreen.SetActive(false);       
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        var activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }


   
}
