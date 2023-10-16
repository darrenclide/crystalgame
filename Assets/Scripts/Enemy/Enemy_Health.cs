using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 3;
    public int currentHealth;
    public GameObject crystal;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamageEnemy(int amount)
    {
        animator.SetTrigger("hurt");
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("enemy died");
        animator.SetBool("dead",true);
        this.GetComponent<Collider2D>().enabled=false;
        this.GetComponent<EnemyScript>().enabled = false;

        GameObject clone;
        clone = Instantiate(crystal, transform.position, transform.rotation);
    }
}
