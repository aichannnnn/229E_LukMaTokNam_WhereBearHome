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
    public GameObject EndScreen;
    public GameObject CreditScreen;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI NormalDialogueText;
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI pointEndText;
    public TextMeshProUGUI PushItemText;
    public TextMeshProUGUI TutorialItemText;

    public Button restartButton;
    public Button startButton;
    public Button nextButton;
    public Button exitButton;

    private int score;

    DialogueSensor dialogueSensor;

    private void Awake()
    {
        Time.timeScale = 0f;
        startButton.onClick.AddListener(() => { StartGame();});
        nextButton.onClick.AddListener(() => { Next(); });
    }

    private void Start()
    {
        dialogueScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        pushScreen.SetActive(false);
        titleScreen.SetActive(true);
        CreditScreen.SetActive(false);
        EndScreen.SetActive(false);
        pointText.gameObject.SetActive(false);
        TutorialItemText.gameObject.SetActive(false);
    }

    void StartGame()
    {
        Time.timeScale = 1f;
        titleScreen.SetActive(false);
        pointText.gameObject.SetActive(true);
        TutorialItemText.gameObject.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        var activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }

    public void UpdateScore(int score)
    {
        this.score += score;
        pointText.text = "Score : " + this.score.ToString();
    }    

    public void Victory(int score)
    {
        Time.timeScale = 0f;
        this.score = score;
        pointEndText.text = this.score.ToString() + " Point";
        pointText.gameObject.SetActive(false);
        TutorialItemText.gameObject.SetActive(false);
        EndScreen.SetActive(true);
    }    

    public void Next()
    {
        EndScreen.SetActive(false);
        CreditScreen.SetActive(true);
    }    

    public void Exit()
    {
        Application.Quit();
    }
   
}
