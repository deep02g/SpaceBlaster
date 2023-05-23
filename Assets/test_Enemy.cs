using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Enemy : MonoBehaviour
{
    public int health = 100;
    public bool dealDamageOnTriggerEnter = true;
    public GameObject deathEffect;
    public int scoreValue = 5;

    
    public void TakeDamage(int damage)
    {
        
        health = health - damage;
        Debug.Log(health);


        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        DoBeforeDestroy();
        Destroy(this.gameObject);
        Debug.Log(health);
    }

    public void DoBeforeDestroy()
    {
        AddToScore();
        IncrementEnemiesDefeated();
    }
    private void IncrementEnemiesDefeated()
    {
        if (GameManager.instance != null && !GameManager.instance.gameIsOver)
        {
            GameManager.instance.IncrementEnemiesDefeated();
        }
    }

    private void AddToScore()
    {
        if (GameManager.instance != null && !GameManager.instance.gameIsOver)
        {
            GameManager.AddScore(scoreValue);
        }
    }
}
