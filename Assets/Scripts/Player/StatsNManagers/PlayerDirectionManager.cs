using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionManager : MonoBehaviour
{  
    private PlayerControlls inputActions ;   

    private PlayerStates player;

    private PlayerStats playerStats;

    private bool controllersInUse;

    [Range(0.5f, 4)]
    [SerializeField]
    [Header("Mouse_Direction_Change_Offset")]
    [Tooltip("it multiplies with the mouse distance from the player in order to minimize it or extend it")]
    private float inputOffset;

    Vector3 currentMousePos;
    private void Awake()
    {
        player = GetComponent<PlayerStates>();
        playerStats = GetComponent<PlayerStats>();
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
            playerStats.boltDirection = transform.right;
        }
        if (Mathf.Approximately(DirectionOfCharacter(), -1))
        {
            player.ChangeDirection(PlayerStates.PlayerDirection.left);
            playerStats.boltDirection = -transform.right;
        }
    }
    private float DirectionOfCharacter()
    {
        Vector2 MousePixelPos = inputActions.MainControlls.DirectionMouse.ReadValue<Vector2>();
        float mouseWorldPosition = Camera.main.ScreenToWorldPoint(MousePixelPos).x;
        float mousePosRelativeToPlayer = (mouseWorldPosition - transform.position.x)*inputOffset;
        float mousePosRelativeToPlayerClamped = Mathf.Clamp(mousePosRelativeToPlayer, -1, 1);
        if (controllersInUse)
        {
            return inputActions.MainControlls.Direction.ReadValue<float>();
        }

        else 
        {
            return mousePosRelativeToPlayerClamped;

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
