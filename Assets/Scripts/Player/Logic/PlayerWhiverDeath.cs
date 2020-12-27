using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWhiverDeath : MonoBehaviour
{   
    private PlayerStats playerStats;
    private Fighting fightingPlayer;



    private Rigidbody2D rb;

    private float _MaxHealth;
    private float _CurrentHealth;
    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        fightingPlayer = GetComponent<Fighting>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _CurrentHealth = Mathf.Infinity;
        _MaxHealth = playerStats.playerHealth;
        PlayerStates.onPlayerBehaviourChange += CheckIfWhiveringAndApplyLogic;
    }

    // Update is called once per frame
    void Update()
    {
        WhiverBehaviourManager(CheckIfDeadAndReturnFalseOnlyIfReachedMaxHealth());
        EnemyResponseToWhivering();
    }
    private void CheckIfWhiveringAndApplyLogic(PlayerStates.Behaviour behaviour)
    {
        if (behaviour.Equals(PlayerStates.Behaviour.Whiver_Die))
        {
            WhiveringPreparation();
            WhiverDie();
        }
        else
        {
            WhiveringStopped();
        }
    }
    void WhiverBehaviourManager(bool whenToWhiver)
    {
        if (whenToWhiver)
        {
            PlayerStates.ChangeBehaviour(PlayerStates.Behaviour.Whiver_Die);
        }
    }

    void WhiverDie()
    {
            playerStats.playerHealth += playerStats.rejuvanationHpAdd*Time.deltaTime;
    }
    private void EnemyResponseToWhivering()
    {   if (CheckIfDeadAndReturnFalseOnlyIfReachedMaxHealth())
        {
            EnemiesMain.ChangeInteraction(EnemiesMain.InteractionsWithPlayer.avoid);
        }
        else
        {
            EnemiesMain.ChangeInteraction(EnemiesMain.InteractionsWithPlayer.none);
        }
    }
    private void WhiveringPreparation()
    {
            fightingPlayer.enabled = false;
            Physics2D.IgnoreLayerCollision(8, 9);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
      
    }
    private void WhiveringStopped()
    {
        fightingPlayer.enabled = true;
        Physics2D.IgnoreLayerCollision(8, 9,false);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

    }
    private bool CheckIfDeadAndReturnFalseOnlyIfReachedMaxHealth()
    {

         if (playerStats.playerHealth<_MaxHealth&&Died())
        {
            return true;
        }
        else
        {
            _CurrentHealth = Mathf.Infinity;
            return false;
        }
    }
    private bool Died()
    {
        if (playerStats.playerHealth <= 0)
        {
            _CurrentHealth = playerStats.playerHealth;
        }
        if (_CurrentHealth < _MaxHealth)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
