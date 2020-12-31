using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")||collision.gameObject.CompareTag("Enemie"))
        {
            PlayerStates.ChangeBehaviour(PlayerStates.Behaviour.jumping);
            PlayerStates.ChangeSurface(PlayerStates.Surface.ground);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayerStates.ChangeSurface(PlayerStates.Surface.air);
        }
    }
}
