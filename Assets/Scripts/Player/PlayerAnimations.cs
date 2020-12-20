using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private PlayerStates playerStates;
    private Animator playerAnimator;
    private SpriteRenderer spriteRenderer;

    public enum AnimationState
    {
        playing,
        stoped
    }
    public delegate void AnimationStateManager(PlayerAnimations.AnimationState animationState);
    public static event AnimationStateManager onStateChange;
    // Start is called before the first frame update
    void Start()
    {
        playerStates = GetComponent<PlayerStates>();
        playerAnimator = GetComponent<Animator>();
        PlayerStates.onPlayerBehaviourChange+= AnimationManager;
        PlayerStates.onDirectionChange += DirectionManager;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        StateChanger();
    }
    private void AnimationManager(PlayerStates.Behaviour behaviour)
    {
        switch (behaviour)
        {
            case PlayerStates.Behaviour.walking:
                //PlayWalkingAnime
                playerAnimator.SetBool("Walk", true);
                playerAnimator.SetBool("Idle", false);
                break;
            case PlayerStates.Behaviour.idle:
                playerAnimator.SetBool("Walk", false);
                playerAnimator.SetBool("Idle", true);
                //play idleAnime
                break;
            case PlayerStates.Behaviour.jumping:
                //play Jumping Anime
                playerAnimator.SetTrigger("Jump");
                break;
            case PlayerStates.Behaviour.attacking:
                playerAnimator.SetTrigger("Attack");
                break;
                
        }
    }
    private void AnimationStateChange(PlayerAnimations.AnimationState animationState)
    {
        if (onStateChange != null)
        {
            onStateChange(animationState);
        }
    }
    private void StateChanger()
    {
        if (CheckIfCurrentAnimationIsPlaying())
        {
            AnimationStateChange(AnimationState.playing);
        }
        else
        {
            AnimationStateChange(AnimationState.stoped);
        }
    }
    private bool CheckIfCurrentAnimationIsPlaying()
    {
        return playerAnimator.GetCurrentAnimatorClipInfo(0).Length >
            playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime
            && !playerAnimator.IsInTransition(0);
    }
    private void DirectionManager(PlayerStates.PlayerDirection direction)
    {
        switch (direction)
        {
            case PlayerStates.PlayerDirection.right:
                spriteRenderer.flipX = false;
                break;
            case PlayerStates.PlayerDirection.left:
                spriteRenderer.flipX = true;
                break;
        }
    }
}
