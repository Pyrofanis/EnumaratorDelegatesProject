using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [HideInInspector]
    public bool grounded;

    private PlayerStates _playerStates;
    // Start is called before the first frame update
    void Start()
    {
        _playerStates = GetComponent<PlayerStates>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {        
                //_playerStates.BehaviourSubscriptionChecker(PlayerStates.Behaviour.grounded);
        }
    }
}
