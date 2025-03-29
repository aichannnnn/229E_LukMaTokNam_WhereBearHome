using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5f;

    private Vector3 offset;
    private bool isJumping;

    PlayerController playerController;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void Update()
    {
        isJumping = Input.GetButton("Jump");

        Vector3 targetPosition = player.position + offset;

        float followY = isJumping ? transform.position.y : targetPosition.y;

        Vector3 smoothPosition = new Vector3(targetPosition.x, followY, targetPosition.z);
        transform.position = Vector3.Lerp(transform.position, smoothPosition, followSpeed * Time.deltaTime);
    }
}
