using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    SpawnManagerX _spawnManagerScript;
    float waveAdjustedSpeed;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");
        _spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>();
    }

    // Update is called once per frame
    void Update()
    {
        //incerases the enemy speed based on the current wave
        waveAdjustedSpeed = speed + (_spawnManagerScript.waveCount * 25);
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * waveAdjustedSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
