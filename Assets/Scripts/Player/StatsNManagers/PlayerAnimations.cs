﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{   
    private static Animator playerAnimator;
    private SpriteRenderer spriteRenderer;

    private Color initialColour;

    public enum AnimationState
    {
        playing,
        stoped
    }
    public delegate void AnimationStateManager(PlayerAnimations.AnimationState animationState);
    public static event AnimationStateManager onStateChange;
    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerStates.onPlayerBehaviourChange+= AnimationManager;
        PlayerStates.onDirectionChange += DirectionManager;
        initialColour = spriteRenderer.color;
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
                playerAnimator.SetBool("Whiver", false);
                break;
            case PlayerStates.Behaviour.idle:
                playerAnimator.SetBool("Idle", true);
                playerAnimator.SetBool("Walk", false);
                playerAnimator.SetBool("Whiver", false);
                //play idleAnime
                break;
            case PlayerStates.Behaviour.Whiver_Die:
                playerAnimator.SetBool("Whiver", true);
                playerAnimator.SetBool("Walk", false);
                playerAnimator.SetBool("Idle", false);
                break;
            case PlayerStates.Behaviour.jumping:
                //play Jumping Anime
                playerAnimator.SetTrigger("Jump");
                break;
            case PlayerStates.Behaviour.attacking:
                playerAnimator.SetTrigger("Attack");
                break;
            case PlayerStates.Behaviour.gotHit:
                playerAnimator.SetTrigger("Hit");
                StartCoroutine(ChangeColourEffect(Color.red, initialColour, 1f));
                break;

                
        }
    }
    private IEnumerator ChangeColourEffect(Color colorToChangeTo,Color colorToReturnTo,float timeToChange)
    {
        spriteRenderer.color = colorToChangeTo;
        yield return new WaitForSeconds(timeToChange);
        spriteRenderer.color = colorToReturnTo;
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
    private static bool CheckIfCurrentAnimationIsPlaying()
    {
        return playerAnimator.GetCurrentAnimatorClipInfo(0).Length >
            playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime
            && !playerAnimator.IsInTransition(0);
    }
    public static bool CheckIfAttackAnimationIsPlaying()
    {   string clipsName;
       AnimatorClipInfo[] clipInfo= playerAnimator.GetCurrentAnimatorClipInfo(0);
        clipsName = clipInfo[0].clip.name;
        return CheckIfCurrentAnimationIsPlaying() && clipsName.Contains("Attack"); 
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
