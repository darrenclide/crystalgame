using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    private  bool dead;
    public Animator animator;
    public GameObject[] crystals;
    public int life;
    // Start is called before the first frame update
    void Start()
    {
        life = crystals.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(life < 1)
        {
            Destroy(crystals[0].gameObject);
            animator.SetBool("death",true);
        }
    }
    public void TakeDamage(int amount)
    {
        life -= amount;
        if(life >= 1)
        {
            Destroy(crystals[life].gameObject);
            animator.SetTrigger("hit");
        }
    }
}
