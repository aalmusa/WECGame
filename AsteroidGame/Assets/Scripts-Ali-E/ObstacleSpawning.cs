using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawning : MonoBehaviour
{
    public GameObject[] asteroids;

    public float maxX;
    public float minX;
    public float ySpawnPoint;
    public float timeBetweenSpawn;
    private float spawnTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }

    }

    void Spawn()
    {
        float x = Random.Range(minX, maxX);
        float y = ySpawnPoint;

        int randAs = Random.Range(0, asteroids.Length);
        GameObject obstacle = asteroids[randAs];

        Instantiate(obstacle, transform.position + new Vector3(x, y, 0), transform.rotation);
    }
}
