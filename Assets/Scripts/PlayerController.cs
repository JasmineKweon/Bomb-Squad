using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    float horizontal;
    float vertical;
    //Rigidbody2D rigidbody2d;
    BoxCollider2D boxCollider;
    Animator animator;
    Vector2 lookDirection = new Vector2(0, -1);
    Vector2 move;

    Vector3 pos;

    int coinNum;

    public GameObject bombPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
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
        RaycastHit2D hitup = Physics2D.Raycast(transform.position, Vector2.up, 0.4f);
        RaycastHit2D hitdown = Physics2D.Raycast(transform.position, Vector2.down, 0.4f);
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, 0.4f);
        RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, 0.4f);
        boxCollider.enabled = true;



        if (horizontal < 0 && transform.position == pos && (hitleft.collider == null || hitleft.collider.gameObject.name.StartsWith("bomb_ground") || hitleft.collider.gameObject.name.StartsWith("coin")))
        {        // Left
            pos += new Vector3(-0.05f, 0, 0);
        }
        if (horizontal > 0 && transform.position == pos && (hitright.collider == null || hitright.collider.gameObject.name.StartsWith("bomb_ground")|| hitright.collider.gameObject.name.StartsWith("coin")))
        {        // Right
            pos += new Vector3(0.05f, 0, 0);
        }
        if (vertical > 0 && transform.position == pos && (hitup.collider == null || hitup.collider.gameObject.name.StartsWith("bomb_ground")|| hitup.collider.gameObject.name.StartsWith("coin")))
        {        // Up
            pos += new Vector3(0, 0.05f, 0);
        }
        if (vertical < 0 && transform.position == pos && (hitdown.collider == null || hitdown.collider.gameObject.name.StartsWith("bomb_ground")|| hitdown.collider.gameObject.name.StartsWith("coin")))
        {        // Down
            pos += new Vector3(0, -0.05f, 0);
        }

        /*
        if (Input.GetKeyDown(KeyCode.H) && transform.position == pos && hitleft.collider == null)
        {
            pos +=Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.K) && transform.position == pos && hitright.collider == null)
        {
            pos +=Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.U) && transform.position == pos && hitup.collider == null)
        {
            pos +=Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.J) && transform.position == pos && hitdown.collider == null)
        {
            pos +=Vector3.down;
        }
        */
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there
    }

    void DropBomb()
    {
        Instantiate(bombPrefab, new Vector3(Mathf.Floor(pos.x) + 0.45f, Mathf.Round(pos.y + 0.5f) - 1), Quaternion.identity);
    }

    public void addCoin()
    {
        coinNum++;
        Debug.Log(gameObject.name + ": " + coinNum);
    }
}