﻿using System;
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
        attacking,
        Whiver_Die
    }
    public enum PlayerDirection
    {
        left,
        right
    }
    public enum Surface
    {
        ground,
        air
    }
    public delegate void BehaviourManager(Behaviour behaviour);
    public static event BehaviourManager onPlayerBehaviourChange;

    public delegate void DirectionManager(PlayerDirection direction);
    public static event DirectionManager onDirectionChange;

    public delegate void SurfaceInteractionManager(Surface surface);
    public static event SurfaceInteractionManager onSurfaceChange;

 public static void ChangeBehaviour(Behaviour behaviour)
    {
        if (onPlayerBehaviourChange != null)
        {
            onPlayerBehaviourChange(behaviour);
        }
    }
    public void ChangeDirection(PlayerDirection direction)
    {
        if (onDirectionChange != null)
        {
            onDirectionChange(direction);
        }
    }
    public static void ChangeSurface(Surface surface)
    {
        if (onSurfaceChange != null)
        {
            onSurfaceChange(surface);
        }
    }
}
