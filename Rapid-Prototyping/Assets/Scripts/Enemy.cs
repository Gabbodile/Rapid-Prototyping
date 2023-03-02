using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameBehaviour<Enemy>
{
    public float enemySpeed = 3.0f;

    private Rigidbody enemyRB;
    private GameObject player;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookDirection * enemySpeed);
        if (transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }
}
