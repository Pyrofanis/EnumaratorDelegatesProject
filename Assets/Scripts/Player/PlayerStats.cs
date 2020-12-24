using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Tooltip("players health ")]
    [Header("Players health")]
    [Range(50, 200)]
    public float playerHealth;
    [Tooltip("The SpeedOf The Player i x axes")]
    [Header("Players Speed")]
    [Range(1, 10)]
    public float speed;
    [Tooltip("The Jump Height Of Player")]
    [Header("Players Jump Height")]
    [Range(100, 1000)]
    public float jumpSpeed;
    [Tooltip("is going To Be Called by the attackScript")]
    [Header("playersDamage")]
    [Range(10, 80)]
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
