using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    private PlayerStates playerStates;
    // Start is called before the first frame update
    void Start()
    {
        playerStates = GetComponent<PlayerStates>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerStates.ChangeBehaviour(PlayerStates.Behaviour.attacking);
        }
    }
}
