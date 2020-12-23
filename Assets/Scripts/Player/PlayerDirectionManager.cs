﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionManager : MonoBehaviour
{  
    private PlayerControlls inputActions ;   

    private PlayerStates player;

    public bool controllersInUse;

    Vector3 currentMousePos;
    private void Awake()
    {
        player = GetComponent<PlayerStates>();
    }
    // Start is called before the first frame update
    void Start()
    {
        inputActions = new PlayerControlls();
        inputActions.Enable();
        currentMousePos = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        DirectionManager();
        CheckIfControllersAreBeingUsed();
    }
    private void DirectionManager()
    {
        if (Mathf.Approximately(DirectionOfCharacter(), 1))
        {
            player.ChangeDirection(PlayerStates.PlayerDirection.right);
        }
        if (Mathf.Approximately(DirectionOfCharacter(), -1))
        {
            player.ChangeDirection(PlayerStates.PlayerDirection.left);
        }
    }
    private float DirectionOfCharacter()
    {
        Vector2 MousePixelPos = inputActions.MainControlls.DirectionMouse.ReadValue<Vector2>();
        float mouseWorldPosition = Camera.main.ScreenToWorldPoint(MousePixelPos).x;
        float mousePosRelativeToPlayer = Mathf.Clamp(mouseWorldPosition - transform.position.x, -1, 1);
        if (controllersInUse)
        {
            return inputActions.MainControlls.Direction.ReadValue<float>();
        }

        else 
        {
            return mousePosRelativeToPlayer;

        }
    }
    private void CheckIfControllersAreBeingUsed() 
    {  

        Vector2 MousePixelPos = inputActions.MainControlls.DirectionMouse.ReadValue<Vector2>();
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(MousePixelPos);
        if (inputActions.MainControlls.Direction.ReadValue<float>() != 0)
        {
            controllersInUse = true;
            currentMousePos = mouseWorldPosition;

        }
        else if (currentMousePos!= mouseWorldPosition)
        {
            controllersInUse = false;
        }

    }

}
