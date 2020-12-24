using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    private PlayerStates playerStates;
    private PlayerStats playerStats;
    private PlayerControlls inputs;
    // Start is called before the first frame update
    private void Awake()
    {
        inputs = new PlayerControlls();
        inputs.Enable();

    }


    void Start()
    {
        inputs.MainControlls.Attack.performed +=_=> Attack(PlayerAnimations.CheckIfAttackAnimationIsPlaying());
        playerStates = GetComponent<PlayerStates>();
        playerStats = GetComponent<PlayerStats>();
    }
    private void Update()
    {
    }

    private void Attack(bool notPlayingAnimation)
    {
        if (!notPlayingAnimation)
        {
            playerStates.ChangeBehaviour(PlayerStates.Behaviour.attacking);
            InstanciateFist();
        }
           
            //add stuff to do like Inv Bullets And Stuff
    }
    private void InstanciateFist()
    {
        Instantiate(playerStats.bulletPrefab, transform.position, Quaternion.identity);
    }
}
