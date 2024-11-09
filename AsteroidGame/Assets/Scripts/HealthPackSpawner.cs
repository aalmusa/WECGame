using UnityEngine;

public class HealthPackSpawner : MonoBehaviour
{
    public GameObject healthPackPrefab; // Assign this in the inspector
    public float spawnRate = 5f; // Time between spawns in seconds
    public float delayAfterCollect = 3f; // Delay after a health pack is collected before another can spawn
    private float nextSpawnTime = 0f;
    private int maxHealthPacks = 2;
    private int currentHealthPacks = 0;

    private Camera mainCamera;
    private Vector2 screenBounds;

    void Start()
    {
        mainCamera = Camera.main; // Get the main camera
        screenBounds = new Vector2(mainCamera.aspect * mainCamera.orthographicSize, mainCamera.orthographicSize);
    }

    void Update()
    {
        // Check the current time against the next scheduled spawn time and the current count of health packs
        if (Time.time >= nextSpawnTime && currentHealthPacks < maxHealthPacks)
        {
            SpawnHealthPack();
        }
    }

    void SpawnHealthPack()
    {
        if (currentHealthPacks >= maxHealthPacks)
        {
            return; // Do not spawn if the maximum number is already present
        }

        if (healthPackPrefab == null)
        {
            Debug.LogError("Health pack prefab is not assigned in the inspector!");
            return;
        }

        Vector2 spawnPosition = new Vector2(
            Random.Range(mainCamera.transform.position.x - screenBounds.x, mainCamera.transform.position.x + screenBounds.x),
            Random.Range(mainCamera.transform.position.y - screenBounds.y, mainCamera.transform.position.y + screenBounds.y)
        );

        GameObject newHealthPack = Instantiate(healthPackPrefab, spawnPosition, Quaternion.identity);
        newHealthPack.transform.SetParent(transform); // Optional: Keep the scene organized

        HealthPack healthPackComponent = newHealthPack.GetComponent<HealthPack>();
        if (healthPackComponent != null)
        {
            healthPackComponent.OnCollected += HealthPackCollected;
            currentHealthPacks++; // Increment the count of health packs
        }
    }

    void HealthPackCollected()
    {
        currentHealthPacks--; // Decrement the count of health packs
        nextSpawnTime = Time.time + delayAfterCollect; // Set the next spawn time after the delay
    }
}
