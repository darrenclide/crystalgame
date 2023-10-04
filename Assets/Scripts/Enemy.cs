using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
        animator = GetComponent<Animator>();
    }

// Update is called once per frame
void Update()
    {
        distance = player.transform.position.x - transform.position.x;

        print(distance);

        if(distance < 1 && distance > -1)
        {
            animator.SetTrigger("attack");
        }
        if(distance < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            print("flipped");
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (distance < 2 && distance > -2)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            animator.SetBool("move", true);
        }
        else
        {
            animator.SetBool("move", false);
        }
        if (distance > 2 || distance < -2)
        {
            speed = 5f;
        }
        else
        {
            speed = 1f;
        }
    }
}