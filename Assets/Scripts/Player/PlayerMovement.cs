using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    private Vector3 horizontalAXES;

    private Rigidbody2D rb;
    private PlayerStates playerStates;

    private bool isMoving;
    [SerializeField]
    private bool canJump;

    private PlayerStates.Behaviour currentBehaviour;

    private PlayerStates.Surface currentSurface;

    private PlayerControlls inputActions;

    private PlayerStats playerStats;
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
        playerStats = GetComponent<PlayerStats>();
        PlayerStates.onPlayerBehaviourChange += MovementStateManager;
        PlayerStates.onSurfaceChange += JumpManager;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement(isMoving);
        MovementStateChanger();


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
            rb.position = Vector2.MoveTowards(rb.position, transform.position + horizontalAXES.normalized, playerStats.speed * Time.deltaTime);
            
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
        StopJumping();
        playerStates.ChangeBehaviour(PlayerStates.Behaviour.jumping);
        yield return new WaitForSeconds(0.2F);
        rb.AddForce(Vector2.up * playerStats.jumpSpeed);
    }
}
