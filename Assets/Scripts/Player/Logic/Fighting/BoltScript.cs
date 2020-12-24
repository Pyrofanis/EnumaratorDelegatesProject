using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour
{   
    private Vector2 bolitDir;

    private PlayerStats playerStats;

    private Rigidbody2D boltRb;

    private Vector2 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        playerStats = FindObjectOfType<PlayerStats>();
        boltRb = GetComponent<Rigidbody2D>();
        bolitDir = playerStats.boltDirection;
    }

    // Update is called once per frame
    void Update()
    {
        boltMovement();
        BoltDestroyer();
    }
    private void boltMovement()
    {
        boltRb.position = Vector2.MoveTowards(boltRb.position, boltRb.position + bolitDir,playerStats.attackResponsiveness*Time.deltaTime);
    }
    private void BoltDestroyer()
    {
        if (Vector2.Distance(initialPos, transform.position) >= playerStats.attackRange)
        {
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(initialPos, transform.position);
    }
}
