using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   [Tooltip("The SpeedOf The Player i x axes")]
    [Header("Players Speed")]
    [Range(1,10)]
    public int speed;
    [Tooltip("The Jump Height Of Player")]
    [Header("Players Jump Height")]
    [Range(100,1000)]
    public int _JumpSpeed;

    private Vector3 horizontalAXES;

    private Rigidbody2D rb;
    private PlayerStates playerStates;

    private bool isMoving;
    private bool canJump;

    private PlayerStates.Behaviour currentBehaviour;

    private PlayerStates.Surface currentSurface;

    private PlayerControlls inputActions;
    // Start is called before the first frame update
    private void Awake()
    {
        inputActions = new PlayerControlls();
    }
    void Start()
    {
        inputActions.MainControlls.JumpAction.performed += _ => JumpState(canJump);
        inputActions.Enable();
        rb = GetComponent<Rigidbody2D>();
        playerStates = GetComponent<PlayerStates>();
        PlayerStates.onPlayerBehaviourChange += MovementStateManager;
        PlayerStates.onSurfaceChange += JumpManager;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement(isMoving);
        MovementStateChanger();
        DirectionStateManager();


    }
     void MovementStateManager(PlayerStates.Behaviour behaviour)
    {
        currentBehaviour = behaviour;
       if (currentBehaviour== PlayerStates.Behaviour.walking)
        {
            StartMoving();
        }
        else
        {
            StopMoving();
        }
    }
    private void StartJumping()
    {
        canJump = true;
    }
    private void StopJumping()
    {
        canJump = false;
    }
    private void StartMoving()
    {
        isMoving = true;
    }
    private void StopMoving()
    {
        isMoving = false;
    }
    private void HorizontalMovement(bool isMoving)
    {   
        horizontalAXES.x = inputActions.MainControlls.Move.ReadValue<float>();
        if (isMoving)
        {
            rb.position = Vector2.MoveTowards(rb.position, transform.position + horizontalAXES.normalized, speed * Time.deltaTime);
            //transform.position = Vector2.MoveTowards(transform.position, transform.position + horizontalAXES, speed * Time.deltaTime);
            //Debug.Log("Horizontal Axe: " + horizontalAXES + ", Add" + (transform.position + horizontalAXES));
        }

    }
    private void MovementStateChanger()
    {
        if (horizontalAXES.x != 0)
        {
            playerStates.ChangeBehaviour(PlayerStates.Behaviour.walking);
        }
        else
        {
            playerStates.ChangeBehaviour(PlayerStates.Behaviour.idle);
        }
    }
    private void DirectionStateManager()
    {
        if (horizontalAXES.x >= 0)
        {
            playerStates.ChangeDirection(PlayerStates.PlayerDirection.right);
        }
        else
        {
            playerStates.ChangeDirection(PlayerStates.PlayerDirection.left);
        }
    }
    private void JumpManager(PlayerStates.Surface surface)
    {
        currentSurface = surface;
        if (currentSurface == PlayerStates.Surface.ground)
        {
            StartJumping();
        }
        else
        {
            StopJumping();
        }
    }
    private void JumpState(bool canJump)
    {   
        if (canJump)
        {         
                StartCoroutine(JumpWithAnimationDelay());
        }
  
    }
    private IEnumerator JumpWithAnimationDelay()
    {
        playerStates.ChangeBehaviour(PlayerStates.Behaviour.jumping);
        yield return new WaitForSeconds(0.2F);
        rb.AddForce(Vector2.up * _JumpSpeed);
    }
}
