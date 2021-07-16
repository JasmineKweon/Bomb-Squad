using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.5f;
    float horizontal;
    float vertical;
    Rigidbody2D rigidbody2d;
    //Animator animator;
    //Vector2 lookDirection = new Vector2(0, -1);
    Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Player1")
        {
            horizontal = Input.GetAxis("Player1-Horizontal");
            vertical = Input.GetAxis("Player1-Vertical");
        }
        else if (gameObject.name == "Player2")
        {
            horizontal = Input.GetAxis("Player2-Horizontal");
            vertical = Input.GetAxis("Player2-Vertical");
        }

        move = new Vector2(horizontal, vertical);
        /*
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("LookX", lookDirection.x);
        animator.SetFloat("LookY", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        Vector2 position = transform.position;

        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        transform.position = position;
        */
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position = position + speed * move * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
}
