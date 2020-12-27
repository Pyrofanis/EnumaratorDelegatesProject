using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMain : MonoBehaviour
{   public enum EnemieStates
    {
        attack,
        avoid,
        gotHit,
        whiver,
        chase,
        death,
        idle

    }
    public enum EnemieDirection
    {
        left,
        right
    }
    public enum InteractionsWithPlayer
    {
        avoid,
        none
    }

    public delegate void EnemieStateManager(EnemieStates enemieStates);
    public  event EnemieStateManager onEnemieStateChanger;

    public delegate void EnemieDirectionManager(EnemieDirection direction);
    public  event EnemieDirectionManager onEnemieDirectionChange;

    public delegate void EnemieInteractionWithPlayer(EnemiesMain.InteractionsWithPlayer interactions);
    public static event EnemieInteractionWithPlayer onInteract;

    public void ChangeEnemieState(EnemieStates enemieState)
    {
        if (onEnemieStateChanger != null)
        {
            onEnemieStateChanger(enemieState);
        }
    }

    public void ChangeDirection(EnemieDirection direction)
    {
        if (onEnemieDirectionChange != null)
        {
            onEnemieDirectionChange(direction);
        }
    }
    public static void ChangeInteraction(InteractionsWithPlayer interactions)
    {
        if (onInteract != null)
        {
            onInteract(interactions);
        }
    }

}
