using UnityEngine;

public class GetDestroyed : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -23)
            Destroy(gameObject);

    }
}