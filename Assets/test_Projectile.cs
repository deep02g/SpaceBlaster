using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Projectile : MonoBehaviour
{
    public float speed;
    public int damage = 40;
    public GameObject impactEffect;
    public Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("Hit registered");
        test_Enemy enemy = hitInfo.GetComponent<test_Enemy>();
        //Debug.Log(enemy.health);
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        //Instantiate(impactEffect, transform.position, transform.rotation);
        if(hitInfo.gameObject.tag == "Platform")
        {
            animator.SetTrigger("impact");
        }
        
        Destroy(this.gameObject);
        

    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    
}
