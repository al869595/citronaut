using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Speed
    public float moveSpeed = 5;
    // Get key input
    public float hInput;

    //prefab to hold projectile script
    public Projectile laserPrefab;

    //check for lasers (only one laser at a time)
    private bool _laserActive;
    private Vector3 startPosition; //store start position


     void Start()
    {
        startPosition = transform.position; //store player starting position
    }
    void Update()
    {
        // Uses key input to change direction
        hInput = Input.GetAxisRaw("Horizontal");

        // Moves player
        transform.Translate(Vector2.right * hInput * moveSpeed * Time.deltaTime);

        //Escape key
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
            Debug.Log("Closing Application...");
        }
        // Spacebar or Left click to shoot
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }


    // Projectile code: Alex Gaylord
    private void Shoot()
    {
        //create laser on players location with no rotation)
        if (!_laserActive)
        {
        Projectile projectile = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
        projectile.destroyed += LaserDestroyed;
        _laserActive = true;
        }
    }

    private void LaserDestroyed()
    {
        _laserActive = false;
    }

     public void RespawnPlayer()
    {
        transform.position = startPosition; //respawn player at start position
    }

}
