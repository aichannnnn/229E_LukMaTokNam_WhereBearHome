using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    public AudioClip pickupsound;
    private AudioSource audioSource;

    public int point = 10;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.volume = 0.2f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playpickupsound();
            Destroy(this.gameObject,pickupsound.length) ;
            gameManager.UpdateScore(point);
        }
    }
    void playpickupsound()
    {
        if (pickupsound != null && audioSource != null)
        {
            audioSource.PlayOneShot(pickupsound);
        }
    }
}
