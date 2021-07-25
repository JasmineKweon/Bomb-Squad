using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.0f;
    float horizontal;
    float vertical;
    //Rigidbody2D rigidbody2d;
    BoxCollider2D boxCollider;
    Animator animator;
    Vector2 lookDirection = new Vector2(0, -1);
    Vector2 move;

    Vector3 pos;

    public GameObject bombPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody2d = GetComponent<Rigidbody2D>();
        boxCollider =GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        pos = transform.position;
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

        //Animation
        move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        //DropBomb
        if (Input.GetKeyDown(KeyCode.M) && gameObject.name == "Player1")
        {
            DropBomb();
        }
        if (Input.GetKeyDown(KeyCode.Z) && gameObject.name == "Player2")
        {
            DropBomb();
        }
    }

    void FixedUpdate()
    {
        /*
        Vector2 position = rigidbody2d.position;
        position = position + speed * move * Time.deltaTime;

        rigidbody2d.MovePosition(position);
        */

        boxCollider.enabled = false;
        RaycastHit2D hitup = Physics2D.Raycast(transform.position, Vector2.up, 1.0f);
        RaycastHit2D hitdown = Physics2D.Raycast(transform.position, Vector2.down, 1.0f);
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, 1.0f);
        RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, 1.0f);
        boxCollider.enabled = true;

        if (horizontal < 0 && transform.position == pos && hitleft.collider == null) 
        {        // Left
            pos += Vector3.left;
        }
        if (horizontal > 0 && transform.position == pos && hitright.collider == null) 
        {        // Right
            pos += Vector3.right;
        }
        if (vertical > 0 && transform.position == pos && hitup.collider == null) 
        {        // Up
            pos += Vector3.up;
        }
        if (vertical < 0 && transform.position == pos && hitdown.collider == null) 
        {        // Down
            pos += Vector3.down;
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there
    }

    void DropBomb()
    {
        Instantiate(bombPrefab, pos - new Vector3(0,0.5f) , Quaternion.identity);        
    }
}