using UnityEngine;

public class ShootThem : MonoBehaviour
{
    public GameObject projectilePrefab; // Drag your projectile prefab here
    public Transform firePoint;         // Assign a firing point (empty GameObject on the ship's front)
    private Transform target;           // Reference to the main character's Transform
    public float projectileSpeed = 10f; // Set the speed of the projectile
    public float fireRate = 2f;         // Set how often the ship fires

    private float fireTimer;
    private float distance;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Calculate direction to the target
        Vector2 direction = (target.position - transform.position).normalized;

        // Update fire timer and shoot if timer exceeds fire rate
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            Shoot(direction);
            fireTimer = 0f;
        }
    }

    void Shoot(Vector2 direction)
    {

        distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance < 30)
        {
            // Instantiate projectile and set its initial position and rotation
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            // Set the projectile's Rigidbody velocity and disable gravity
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;                 // Ensure gravity does not affect the projectile
            rb.freezeRotation = true;            // Prevent rotation to maintain straight path
            rb.linearVelocity = direction * projectileSpeed;

            // Optional: Destroy the projectile after a certain time to avoid clutter
            Destroy(projectile, 5f);
        }
    }

}
