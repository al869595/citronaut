using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f; //speed of the projectile
    private Vector3 direction = Vector3.up; //move up by default
    public System.Action destroyed; //notify destruction

    void Update()
    {
        //move projectile upwards
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyManager enemyManager = FindObjectOfType<EnemyManager>();
            if (enemyManager != null)
            {
                enemyManager.EnemyDefeated();
            }

            Destroy(other.gameObject); //destroy enemy
        }

        

        
        if (destroyed != null)
        {
            destroyed.Invoke();
        }

        Destroy(gameObject); //destroy the projectile
    }
}