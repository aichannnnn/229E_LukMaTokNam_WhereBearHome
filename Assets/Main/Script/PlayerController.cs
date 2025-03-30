using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float jumpForce;
    public float speed;
    public float gravityModifier;
    private bool isOnGround = true;
    private bool isGameOver = false;
    public int point = 10;

    private Rigidbody rb;
    GameManager gameManager;

    private InputAction moveAction;
    private InputAction jumpAction;
    public AudioSource playerAudio;
    public AudioClip jumpFx;
    public AudioClip crashFx;

    private Quaternion initialRotation; 

    private void Awake()
    {
        var playerInput = new PlayerInput();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        rb = GetComponent<Rigidbody>();
        isGameOver = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //initialPosition = transform.position; 
        initialRotation = transform.rotation; 
    }

    private void Start()
    {
        rb.mass = 1f;
        Physics.gravity = new Vector3(0, -9.81f, 0);
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetPositionAndRotation();
        }
        float horizontal = 0f;
        float vertical = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            horizontal = 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            horizontal = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vertical = 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vertical = -1f;
        }

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        if (jumpAction.triggered && isOnGround == true)
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpFx, 5);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Obstracle"))
        {
            playerAudio.PlayOneShot(crashFx, 5);
            Debug.Log("Our baby can't go home!");
            gameManager.TutorialItemText.gameObject.SetActive(false);
            gameManager.pointText.gameObject.SetActive(false);
            isGameOver = true;
            GameOver();
        } 
    }
    private void ResetPositionAndRotation()
    {
        //transform.position = initialPosition;
        transform.rotation = initialRotation;
        //rb.linearVelocity = Vector3.zero; 
        rb.angularVelocity = Vector3.zero;  
    }

    public void GameOver()
    {
        if (isGameOver == true)
        {
            Time.timeScale = 0f;
            gameManager.gameOverScreen.SetActive(true);
            gameManager.dialogueScreen.SetActive(false);
            gameManager.pushScreen.SetActive(false);
        }
    }
}
