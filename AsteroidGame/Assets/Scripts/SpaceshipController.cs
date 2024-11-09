using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float speed = 5f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;

        // Calculate the new position
        Vector3 newPosition = transform.position + movement;

        // Calculate camera boundaries
        float cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float cameraHalfHeight = mainCamera.orthographicSize;

        // Clamp the position within camera boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, -cameraHalfWidth, cameraHalfWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, -cameraHalfHeight, cameraHalfHeight);

        // Apply the clamped position
        transform.position = newPosition;
    }
}