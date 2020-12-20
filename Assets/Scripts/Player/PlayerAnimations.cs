using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private PlayerStates playerStates;
    private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerStates = GetComponent<PlayerStates>();
        playerAnimator = GetComponent<Animator>();
        playerStates.onPlayerBehaviourChange += AnimationManager;
    }

    // Update is called once per frame
    void Update()
    {
        
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
                
        }
    }
    private void DirectionManager()
    {

    }
}
