using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieStats : MonoBehaviour
{   [Header("Health Of Enemie")]
    [Tooltip("Will be used by death Script/Attack script /avoid and whiver")]
    [Range(10,500)]
    public float health;
    [Header("Speed Of Enemie")]
    [Range(1,5)]
    public float speed;
    [Header("Enemie's Attack Stats")]
    [Tooltip("Will be used by attack script obviously")]
    public float dmg;
    [Range(0.5f,2)]
    public float attackRate;

    [Header("Enemie's rejuvanation rate while whivering")]
    [Tooltip("Will be used by whivering script")]
    [Range(0.5f, 10)]
    public float rateOfRejuvanation;

    [Header("The Distance To Escape considered Safe")]
    [Tooltip("Used By Avoid State")]
    [Range(0.5f,10)]
    public float SafeDistance=1f;

    [HideInInspector]
    public Rigidbody2D enemiesRigidBody;

    [Header("Define the importance of enemy")]
    public bool itsABoss;

    [Header("Layers to check")]
    [Tooltip("Used by behaviour manage script in order to define who is what")]
    public LayerMask _PlayersLayer;
    public LayerMask _EnemiesLayer;

    [Header("Jump Ammount")]
    [Tooltip("The ammount of force that is going to be added to the game object")]
    public Vector2 jumpAmount;

    [Header("Jump rate")]
    [Tooltip("TimeItTakesToJump Maximum it will be bettween 2  constants (Min[x],Max[y])")]
    [HideInInspector]
    public Vector2 jumpRate;
    [Range(0.5f, 5)]
    public float jumpRateMin;
    [Range(0.5f, 5)]
    public float jumpRateMax;

    [Header("Players stats Object")]
    [Tooltip("ignore not hidden only for debug")]
    public PlayerStats playerStats;
    private void Awake()
    {
        playerStats = GameObject.FindObjectOfType<PlayerStats>();
        enemiesRigidBody = GetComponent<Rigidbody2D>();
        jumpRate = new Vector2(jumpRateMin, jumpRateMax);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, SafeDistance);
    }


}
