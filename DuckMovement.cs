using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    // Speed
    public float moveSpeed;
    public GameObject missilePrefab; //assign the missile prefab
    public float fireRate = 3f; //time between shots
    private float nextFireTime = 0f; // Timer for firing
    void Update()
    {
        // Side to side movement
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        //shoot missile in intervals
        if (Time.time >= nextFireTime)
        {
            ShootMissile();
            nextFireTime = Time.time + fireRate;
        }
    }

    // Downward movement
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Collider"){
            transform.position = new Vector3(transform.position.x, transform.position.y -1, transform.position.z);
            moveSpeed *= -1;
        }
    }
    
    private void ShootMissile()
    {
         Instantiate(missilePrefab, transform.position, Quaternion.identity); //instantiate missle at invaders current position
    }
   
}