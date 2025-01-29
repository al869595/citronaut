using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 5f; //speed of the missile
    private Vector3 direction = Vector3.down; //missiles move downward

    void Update()
    {
        //move projectile downward
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //check if the missile hits the player
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().RespawnPlayer(); //call respawn function
        }

        //destroy the missile on collision
        Destroy(gameObject);
    }
}