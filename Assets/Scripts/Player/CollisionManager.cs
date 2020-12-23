using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{

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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _playerStates.ChangeBehaviour(PlayerStates.Behaviour.jumping);
            _playerStates.ChangeSurface(PlayerStates.Surface.ground);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            _playerStates.ChangeSurface(PlayerStates.Surface.air);
        }
    }
}
