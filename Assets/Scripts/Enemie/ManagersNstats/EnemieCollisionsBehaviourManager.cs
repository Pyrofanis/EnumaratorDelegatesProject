﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieCollisionsBehaviourManager : MonoBehaviour
{
    private EnemiesMain enemiesMain;

    private EnemieStats enemieStats;

    private EnemiesMain.EnemieStates currentBehabiour;

    private float timer;
    private float jumpTimer;
    private Collider2D enemiesCollider;
    private Collider2D playersColliderToIgnore;


    private void Awake()
    {
        enemiesMain = GetComponent<EnemiesMain>();
        enemieStats = GetComponent<EnemieStats>();
        enemiesCollider = GetComponent<Collider2D>();
    }
// Start is called before the first frame update
    void Start()
    {
        PlayersColliderToIgnore();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        jumpTimer += Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Physics2D.IgnoreCollision(playersColliderToIgnore, enemiesCollider);
        if (other.CompareTag("Player") && timer >= enemieStats.attackRate)
        {
            timer = 0;
            enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.attack);
        }
        if (other.CompareTag("PlayersFists"))
        {
            enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.gotHit);
        }
 

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && timer >= enemieStats.attackRate)
        {
            timer = 0;
            enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.attack);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundaries"))
        {
            enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.idle);

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemie"))
        {
            if (jumpTimer >= Random.Range(enemieStats.jumpRate.x, enemieStats.jumpRate.y))
            {
                enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.jump);
                jumpTimer = 0;
            }

        }
    }
    private void PlayersColliderToIgnore()
    {
        Collider2D[] PlayerColliders;
        PlayerColliders =enemieStats.playerStats.GetComponents<Collider2D>();
        foreach (Collider2D coli in PlayerColliders)
        {
            if (!coli.isTrigger)
            {
                playersColliderToIgnore = coli;
            }
        }
    }
}
