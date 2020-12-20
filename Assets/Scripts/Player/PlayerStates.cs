using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{   public enum Behaviour
    {
        idle,
        walking,
        jumping,
        gotHit,
    }

    public delegate void BehaviourManager(Behaviour behaviour);
    public static event BehaviourManager onPlayerBehaviourChange;

    // Start is called before the first frame update
    void Start()
    {
        onPlayerBehaviourChange += ChangeBehaviour;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 public void ChangeBehaviour(Behaviour behaviour)
    {
        if (onPlayerBehaviourChange != null)
        {
            onPlayerBehaviourChange(behaviour);
        }
    }
}
