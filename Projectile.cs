using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f; // Speed of the projectile
    private Vector3 direction = Vector3.up; // Move upwards by default
    public System.Action destroyed; // Event to notify destruction

    void Update()
    {
        // Move the projectile upwards
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

            Destroy(other.gameObject); // Destroy enemy
        }

        if (other.CompareTag("Boundary"))
        {
            Debug.Log("Projectile hit the boundary! Destroying.");
        }

        // Ensure that destroyed.Invoke() is called before the projectile is destroyed
        if (destroyed != null)
        {
            destroyed.Invoke();
        }

        Destroy(gameObject); // Destroy the projectile
    }
}