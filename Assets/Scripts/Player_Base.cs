using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player_Base : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        float speed = 1f;
        if (Input.GetKey("left shift") == true)
        {
            speed = 3f;
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack");
        }
        if (Input.GetKeyDown("w") == true && isTouchingGround)
        {
            print("player pressed w");
            rb.AddForce(new Vector3(0, 3, 0), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
        if (Input.GetKey("a") == true)
        {
            animator.SetFloat("Speed", 1);
            print("player pressed a");
            gameObject.transform.localScale = new Vector3(-2,2,2);
            transform.position = new Vector2(transform.position.x - (1 * speed * Time.deltaTime), transform.position.y);
        }
        else if (Input.GetKey("d") == true)
        {
            animator.SetFloat("Speed", 1);
            print("player pressed d");
            gameObject.transform.localScale = new Vector3(2,2,2);
            transform.position = new Vector2(transform.position.x + (1 * speed * Time.deltaTime), transform.position.y);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }
}