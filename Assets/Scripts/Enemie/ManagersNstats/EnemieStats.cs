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
    [Range(0.15f, 0.5f)]
    public float rateOfRejuvanation;

    [Header("The Distance To Escape considered Safe")]
    [Tooltip("Used By Avoid State")]
    [Range(4,10)]
    public float SafeDistance;

    [HideInInspector]
    public Rigidbody2D enemiesRigidBody;

    [Header("Players stats Object")]
    [Tooltip("ignore not hidden only for debug")]
    public PlayerStats playerStats;
    private void Awake()
    {
        playerStats = GameObject.FindObjectOfType<PlayerStats>();
        enemiesRigidBody = GetComponent<Rigidbody2D>();
    }

   
}
