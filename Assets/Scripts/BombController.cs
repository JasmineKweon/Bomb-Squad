using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float timeout = 6.0f;
    float timer;
    Animator animator;

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
        if ((timer < 1.0f) && (timer > 0.0f))
        {
            animator.SetTrigger("Explode");
        } 
        else if (timer < 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
