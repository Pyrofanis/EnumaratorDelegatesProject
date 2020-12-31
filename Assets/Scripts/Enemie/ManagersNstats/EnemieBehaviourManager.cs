using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemieAnimationManager),typeof(EnemieCollisionsBehaviourManager),typeof(EnemieDirectionManager))]
[RequireComponent(typeof(EnemieChase),typeof(EnemieAttack),typeof(EnemieStats))]
[RequireComponent(typeof(EnemieDeath),typeof(EnemiesMain),typeof(EnemieGotHit))]
public class EnemieBehaviourManager : MonoBehaviour
{
    private EnemieStats enemieStats;
    private EnemiesMain enemiesMain;

    private float maxhHealth;

   

    private bool playerInbound;
    private bool alone;

    private bool avoidingGroup;

    // Start is called before the first frame update
    void Start()
    {
        enemieStats = GetComponent<EnemieStats>();
        enemiesMain = GetComponent<EnemiesMain>();
        EnemiesMain.onInteract += CheckIntetactionsWithPlayer;
        enemiesMain.onEnemieStateChanger += CheckAndApplyUniversalRequirements;
        maxhHealth = enemieStats.health;
    }


    // Update is called once per frame
    void Update()
    {
        Chase();
        Death();
        CheckIfPlayerOrEnemieNear();
        if (!enemieStats.itsABoss)
        {
            Avoid();
            Whiver();
        }


    }
    private void CheckAndApplyUniversalRequirements(EnemiesMain.EnemieStates state)
    {
        if (state.Equals(EnemiesMain.EnemieStates.whiver) || state.Equals(EnemiesMain.EnemieStates.idle)
            || state.Equals(EnemiesMain.EnemieStates.avoid)|| state.Equals(EnemiesMain.EnemieStates.jump))
        {
            Physics2D.IgnoreLayerCollision(8, 8);

        }
        else
        {
            Physics2D.IgnoreLayerCollision(8, 8, false);
        }
    }
    private void CheckIntetactionsWithPlayer(EnemiesMain.InteractionsWithPlayer interactions)
    {
        if (interactions.Equals(EnemiesMain.InteractionsWithPlayer.avoid))
        {
            avoidingGroup = true;
        }
        else
        {
            avoidingGroup = false;
        }
    }
    private void Chase()
    {
        if ((enemieStats.health > maxhHealth / 2 )||!alone && !avoidingGroup)
        {
            enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.chase);
        }

    }
    private void Death()
    {
        if (enemieStats.health <= 0)
        {
            enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.death);

        }
    }
    private void Avoid()
    {
        if (((enemieStats.health <= maxhHealth / 2) || avoidingGroup))
        {   
            if (playerInbound)
            {
                enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.avoid);
            }
            else
            {
                enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.idle);
            }
        }


    }

    private void Whiver()
    {
        if (alone && enemieStats.health <= maxhHealth / 2)
        {
            enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.whiver);
        }

    }
    private void CheckIfPlayerOrEnemieNear()
    {
        Collider2D[] playerColliders = Physics2D.OverlapCircleAll(transform.position, enemieStats.SafeDistance, enemieStats._PlayersLayer);
        Collider2D[] allies = Physics2D.OverlapCircleAll(transform.position, enemieStats.SafeDistance, enemieStats._EnemiesLayer);
        if (playerColliders.Length > 0)
        {
            playerInbound = true;
        }
        else
        {
            playerInbound = false;
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
    private float DistanceFromPlayer()
    {
        return Vector2.Distance(transform.position, enemieStats.playerStats.transform.position);
    }



}
