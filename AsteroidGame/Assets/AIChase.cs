using UnityEngine;

public class AIChase : MonoBehaviour
{
    private GameObject player;
    public float speed;
    private float distance;
    Animator animator;
    bool explInProgress = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;

        // Rotate the object to face the player
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        // transform.rotation = Quaternion.Euler(Vector3.forward * angle);

    }

    
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Bullet")){
            StartExplosion();
            Destroy(other.gameObject);
        }
    }

    public void StartExplosion()
    {
        if (!explInProgress)
        {
            explInProgress = true;
            animator.SetBool("expl", true);
        }
    }
}
