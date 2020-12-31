using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieJump : MonoBehaviour
{
    private EnemiesMain enemiesMain;
    private EnemieStats enemieStats;

    private Vector2 _JumpForce;
    private void Awake()
    {
        enemieStats = GetComponent<EnemieStats>();
        enemiesMain = GetComponent<EnemiesMain>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _JumpForce = enemieStats.jumpAmount;
        enemiesMain.onEnemieStateChanger += CheckIfJumpAndApply;
        enemiesMain.onEnemieDirectionChange += CheckWhatForceToApply;
    }

private void CheckIfJumpAndApply(EnemiesMain.EnemieStates state)
    {
        if (state.Equals(EnemiesMain.EnemieStates.jump))
        {
            Jump();
        }
    }
    private void CheckWhatForceToApply(EnemiesMain.EnemieDirection direction)
    {
        switch (direction)
        {
            case EnemiesMain.EnemieDirection.left:
                _JumpForce.x = enemieStats.jumpAmount.x;
                break;
            case EnemiesMain.EnemieDirection.right:
                _JumpForce.x = -enemieStats.jumpAmount.x;
                break;
        }
    }
    private void Jump()
    {
        enemieStats.enemiesRigidBody.AddForce(_JumpForce);
    }
}
