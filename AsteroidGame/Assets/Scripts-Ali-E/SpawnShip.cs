using UnityEngine;

public class SpawnShip : MonoBehaviour
{
    public GameObject[] ships;
    int counter2 = 0;
    private GameObject player;
    public float maxX;
    public float minX;
    public float ySpawnPoint;
    public float timeBetweenSpawn;
    private float spawnTime;
    private float numberOfSpawns = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime && numberOfSpawns < 20)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
            numberOfSpawns++;
        }
    

    }

    void Spawn()
    {
        float x = player.transform.position.x - 10;
        float y = player.transform.position.y - 10;

        GameObject obstacle = ships[counter2%5];
        counter2++;

        Instantiate(obstacle, transform.position + new Vector3(x, y, 0), transform.rotation);
    }
}
