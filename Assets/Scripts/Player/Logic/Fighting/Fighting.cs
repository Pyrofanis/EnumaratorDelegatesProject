using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
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
        playerStats = GetComponent<PlayerStats>();
        inputs.MainControlls.Attack.performed += _ => Attack(PlayerAnimations.CheckIfAttackAnimationIsPlaying());
    }
    private void OnEnable()
    {
        inputs.Enable();
    }
    private void OnDisable()
    {
        inputs.Disable();
    }
    private void Attack(bool notPlayingAnimation)
    {
        if (!notPlayingAnimation)
        {
            PlayerStates.ChangeBehaviour(PlayerStates.Behaviour.attacking);
            InstanciateFist();
        }
           
            //add stuff to do like Inv Bullets And Stuff
    }
    private void InstanciateFist()
    {
        Instantiate(playerStats.bulletPrefab, transform.position, Quaternion.identity);
    }
}
