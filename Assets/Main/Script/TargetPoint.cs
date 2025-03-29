using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    public int point = 10;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            gameManager.UpdateScore(point);
        }
    }
}
