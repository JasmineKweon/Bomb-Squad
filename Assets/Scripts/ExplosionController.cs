using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    public float explosionTimer = 0.5f;
    bool destroyObject = true;

    public GameObject coinPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

    // Update is called once per frame
    void Update()
    {
        explosionTimer -= Time.deltaTime;
        if (explosionTimer < 0)
        {
            destroyObject = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.StartsWith("Medieval_props_free_10"))
        {
            Destroy(other.gameObject);
            Instantiate(coinPrefab, other.gameObject.transform.position, Quaternion.identity);
        }
        if (other.gameObject.name.StartsWith("Player") && destroyObject == true)
        {
            Destroy(other.gameObject);
        }
    }
}
