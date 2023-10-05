using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    private int maxLife;
    private  bool dead;
    public Animator animator;
    public GameObject[] crystals;
    public int life;
    // Start is called before the first frame update
    void Start()
    {
        
        life = crystals.Length;
        maxLife = life;
    }

    // Update is called once per frame
    void Update()
    {
        if(life < 1)
        {
            dead = true;
            Destroy(crystals[0].gameObject);
            animator.SetBool("death",true);
        }
    }
    public void TakeDamage(int amount)
    {
        life -= amount;
        if(life >= 1)
        {
            crystals[life].gameObject.SetActive(false);
            animator.SetTrigger("hit");
        }
    }
    public void AddLife()
    {
        if(life < maxLife && dead == false)
        {
            crystals[life].gameObject.SetActive(true);
            life += 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Potion" && life < maxLife)
        {
            AddLife();
            Destroy(collision.gameObject);
        }
    }
}
