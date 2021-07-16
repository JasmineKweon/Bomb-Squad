using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float timeout = 3.0f;
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
        if (timer < 0)
        {
            animator.SetTrigger("Explode");
        }
    }
}
