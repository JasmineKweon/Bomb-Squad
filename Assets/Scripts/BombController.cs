using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float timeout = 3.0f;
    Animator animator;
    public GameObject explosionPrefab;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = timeout;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        timer -= Time.deltaTime; 
        if (timer < 0.0f)
        {
            Instantiate(explosionPrefab, gameObject.transform.position + Vector3.left, Quaternion.identity);
            Instantiate(explosionPrefab, gameObject.transform.position + Vector3.right, Quaternion.identity);
            Instantiate(explosionPrefab, gameObject.transform.position + Vector3.up, Quaternion.identity);
            Instantiate(explosionPrefab, gameObject.transform.position + Vector3.down, Quaternion.identity);
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy (gameObject); 
        }
    }
}
