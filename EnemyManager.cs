using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    private int enemyCount;

    void Start()
    {
        //count all objects tagged as "Enemy" at the start of the scene
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void EnemyDefeated()
    {
        enemyCount--; //reduce the enemy count

        //no enemies remain, load the next scene
        if (enemyCount <= 0)
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("Level 2"); //put in actual scene name
    }
}