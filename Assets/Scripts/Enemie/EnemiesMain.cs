using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMain : MonoBehaviour
{   public enum EnemieStates
    {
        attack,
        avoid,
        gotHit,
        hover,
        chase

    }
    public delegate void EnemieStateManager(EnemieStates enemieStates);
    public static event EnemieStateManager onEnemieStateChanger;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChangeEnemieState(EnemieStates enemieState)
    {
        if (onEnemieStateChanger != null)
        {
            onEnemieStateChanger(enemieState);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
