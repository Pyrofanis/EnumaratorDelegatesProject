﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieBehaviourManager : MonoBehaviour
{
    private EnemieStats enemieStats;
    private EnemiesMain enemiesMain;

    private float maxhHealth;

    [Header("Define the importance of enemy")]
    public bool itsABoss;

    [Header("Layers to check")]
    public LayerMask _PlayersLayer;
    public LayerMask _EnemiesLayer;


    [Header("Enemies Safe Distance")]
    public float enemieRadius;

    private bool iAmAlive = true;
    private bool playerInbound;
    private bool alone;


    // Start is called before the first frame update
    void Start()
    {
        enemieStats = GetComponent<EnemieStats>();
        enemiesMain = GetComponent<EnemiesMain>();
        maxhHealth = enemieStats.health;
    }
    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
        Death();
        CheckIfPlayerOrEnemieNear();
        if (!itsABoss)
        {
            Avoid();
            Whiver();
        }


    }


    private void Chase()
    {
        if (enemieStats.health > maxhHealth / 2)
        {
            enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.chase);
        }

    }
    private void Death()
    {
        if (enemieStats.health <= 0)
        {
            iAmAlive = false;
            enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.death);

        }
    }
    private void Avoid()
    {
        if (enemieStats.health <= maxhHealth / 2 && playerInbound && iAmAlive)
        {
            enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.avoid);
        }
    }

    private void Whiver()
    {
        if (alone && enemieStats.health != maxhHealth)
        {
            enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.whiver);
        }
        else if (alone)
        {
            enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.chase);
        }
    }
    private void CheckIfPlayerOrEnemieNear()
    {
        Collider2D[] playerColliders = Physics2D.OverlapCircleAll(transform.position, enemieRadius, _PlayersLayer);
        Collider2D[] allies= Physics2D.OverlapCircleAll(transform.position, enemieRadius, _EnemiesLayer);
        foreach (Collider2D coli in playerColliders)
        {
            if (coli.CompareTag("Player"))
            {
                playerInbound = true;
            }
            else
            {
                playerInbound = false;
            }
        }
        if (allies.Length.Equals(1))
        {
            alone = true;
        }
        else
        {
            alone = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, enemieRadius);
    }


}