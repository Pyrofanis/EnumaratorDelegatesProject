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
    [Range(2,5)]
    public int _JumpSpeed;

    private Vector3 horizontalAXES;

    private Rigidbody2D rb;
    private PlayerStates playerStates;
    private CollisionManager collisionManager;

    private bool isMoving;

    private PlayerStates.Behaviour currentBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerStates = GetComponent<PlayerStates>();
        playerStates.onPlayerBehaviourChange += MovementStateManager;
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
       if (currentBehaviour == PlayerStates.Behaviour.jumping)
        {
            Jump(KeyCode.Space);
        }
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
        horizontalAXES.x = Input.GetAxisRaw("Horizontal");
        if (isMoving)
        {
            Vector2.MoveTowards(transform.position, transform.position+ horizontalAXES.normalized, speed * Time.deltaTime);

        }
  
    }
    private void MovementStateChanger()
    {
        if (horizontalAXES.x != 0&&currentBehaviour!=PlayerStates.Behaviour.walking)
        {
            playerStates.ChangeBehaviour(PlayerStates.Behaviour.walking);
        }
        else if (currentBehaviour!=PlayerStates.Behaviour.idle)
        {
            playerStates.ChangeBehaviour(PlayerStates.Behaviour.idle);
        }
    }
    private void Jump(KeyCode jumpKey)
    {   if (Input.GetKey(jumpKey))
        {
            rb.AddForce(Vector2.up * _JumpSpeed * Time.deltaTime);
        }
    }
}
