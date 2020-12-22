using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionManager : MonoBehaviour
{   private PlayerControlls inputActions ;
    
    private float direction;

    private Vector2 mouseDirection;

    private PlayerStates player;
    private void Awake()
    {
        player = GetComponent<PlayerStates>();
    }
    // Start is called before the first frame update
    void Start()
    {
        inputActions = new PlayerControlls();
        inputActions.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        DirectionManager();
        ResetInput();
    }
    private void DirectionManager()
    {   
        direction = inputActions.MainControlls.Direction.ReadValue<float>();
        //mouseDirection.x = (inputActions.MainControlls.DirectionMouse.ReadValue<Vector2>().x - transform.position.x);
        Debug.Log(direction);
        if (direction .Equals(1)|| mouseDirection.normalized.x.Equals(1))
        {
            player.ChangeDirection(PlayerStates.PlayerDirection.right);
        }
        if (direction.Equals(-1)||mouseDirection.normalized.x.Equals(-1))
        {
            player.ChangeDirection(PlayerStates.PlayerDirection.left);
        }
    }
    private void ResetInput()
    {
     if (direction.Equals(1)||direction.Equals(-1))
        {
            mouseDirection.x = 0;
        }   
    }
}
