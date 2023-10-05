using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public GameObject player;
    public float speed;
    private float point;
    private float distance;
    public Animator animator;
    bool enemyMode;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPoint = pointB.transform;
    }

// Update is called once per frame
void Update()
    {
        point = currentPoint.position.x - transform.position.x;
        distance = player.transform.position.x - transform.position.x;

        if(distance < 0.5 && distance > -0.5)
        {
            animator.SetTrigger("attack");
        }
        if(distance < 0 && distance > -2) 
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(distance > 0 && distance < 2)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

    // Check if the goblin is near the current point
    if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
    {
        // If near point B, flip and move to point A
        if (currentPoint == pointB.transform)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            currentPoint = pointA.transform;
        }
        // If near point A, flip and move to point B
        else if (currentPoint == pointA.transform)
        {
            transform.localScale = new Vector3(1, 1, 1);
            currentPoint = pointB.transform;
        }
    }
        if (distance < 1 && distance > -1)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            animator.SetBool("move", true);
            enemyMode = true;

        }
        else if(enemyMode == false)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, currentPoint.position, speed * Time.deltaTime);
            animator.SetBool("move", true);
        }
        else
        {
            enemyMode = false;
            animator.SetBool("move", false);
        }
    }
}