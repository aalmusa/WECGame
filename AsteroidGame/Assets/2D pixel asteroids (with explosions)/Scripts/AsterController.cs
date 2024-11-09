using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsterController : DestroyAfterExpl
{
    bool explInProgress = false;

    public GameObject explosionPrefab;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartExplosion()
    {
        if (!explInProgress)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject); // Destroys the asteroid
            explInProgress = true;
            animator.SetBool("expl", true);
        }
    }

    
}
