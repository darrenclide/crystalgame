using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player_Base : MonoBehaviour
{
    float floatValue = 1.5f;
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

        if( isTouchingGround )
        {
            animator.SetBool("fall",false);
        }
        else
        {
            animator.SetBool("fall", true);
        }
        if (Input.GetKeyDown(KeyCode.Space) == true && isTouchingGround)
        {
            rb.AddForce(new Vector3(0, 3, 0), ForceMode2D.Impulse);
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }
        if (Input.GetKey("a") == true)
        {
            animator.SetBool("move", true);
            gameObject.transform.localScale = new Vector3(-1,1,1);
            transform.position = new Vector2(transform.position.x - (floatValue * Time.deltaTime), transform.position.y);
        }
        else if (Input.GetKey("d") == true)
        {
            animator.SetBool("move", true);
            gameObject.transform.localScale = new Vector3(1,1,1);
            transform.position = new Vector2(transform.position.x + (floatValue * Time.deltaTime), transform.position.y);
        }
        else
        {
            animator.SetBool("move", false);
        }
    }
}