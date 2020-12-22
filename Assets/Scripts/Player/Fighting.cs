using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    private PlayerStates playerStates;
    private PlayerControlls inputs;
    // Start is called before the first frame update
    private void Awake()
    {
        inputs = new PlayerControlls();
        inputs.Enable();

    }


    void Start()
    {
        inputs.MainControlls.Attack.performed +=_=> Attack();
        playerStates = GetComponent<PlayerStates>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void Attack()
    {
            playerStates.ChangeBehaviour(PlayerStates.Behaviour.attacking);
            //add stuff to do like Inv Bullets And Stuff
    }
}
