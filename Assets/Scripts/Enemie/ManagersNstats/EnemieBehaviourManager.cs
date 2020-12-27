using System.Collections;
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

    private bool playerInbound;
    private bool alone;

    private bool avoidingGroup;

    // Start is called before the first frame update
    void Start()
    {
        enemieStats = GetComponent<EnemieStats>();
        enemiesMain = GetComponent<EnemiesMain>();
        EnemiesMain.onInteract += CheckIntetactionsWithPlayer;
        maxhHealth = enemieStats.health;
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
        if (enemieStats.health > maxhHealth / 2&&!avoidingGroup)
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
        if ((enemieStats.health <= maxhHealth / 2 || avoidingGroup) && playerInbound)
        {
            enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.avoid);
        }


    }

    private void Whiver()
    {
        if (alone && enemieStats.health <= maxhHealth/4)
        {
            enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.whiver);
        }
    }
    private void CheckIfPlayerOrEnemieNear()
    {
        Collider2D[] playerColliders = Physics2D.OverlapCircleAll(transform.position, enemieRadius, _PlayersLayer);
        Collider2D[] allies= Physics2D.OverlapCircleAll(transform.position, enemieRadius, _EnemiesLayer);
        if (playerColliders.Length>0)
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
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, enemieRadius);
    }


}
