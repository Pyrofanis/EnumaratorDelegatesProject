﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieAnimationManager : MonoBehaviour
{
    private Animator enemieAnimator;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        enemieAnimator = GetComponent<Animator>();
        EnemiesMain.onEnemieStateChanger += ApplyAnimations;
    }
    private void ApplyAnimations(EnemiesMain.EnemieStates states)
    {
        switch (states)
        {
            case EnemiesMain.EnemieStates.attack:
                enemieAnimator.SetTrigger("Attack");
                break;
            case EnemiesMain.EnemieStates.gotHit:
                enemieAnimator.SetTrigger("Hit");
                StartCoroutine(colorEffect(Color.red));
                break;
            case EnemiesMain.EnemieStates.death:
                enemieAnimator.SetTrigger("Death");
                break;
            case EnemiesMain.EnemieStates.chase:
                enemieAnimator.SetBool("Walk", true);
                enemieAnimator.SetBool("Idle", false);
                enemieAnimator.SetBool("Whiver", false);
                break;
            case EnemiesMain.EnemieStates.avoid:
                enemieAnimator.SetBool("Walk", true);
                enemieAnimator.SetBool("Idle", false);
                enemieAnimator.SetBool("Whiver", false);
                break;
            case EnemiesMain.EnemieStates.idle:
                enemieAnimator.SetBool("Walk", false);
                enemieAnimator.SetBool("Idle", true);
                enemieAnimator.SetBool("Whiver", false);
                break;
            case EnemiesMain.EnemieStates.whiver:
                enemieAnimator.SetBool("Walk", false);
                enemieAnimator.SetBool("Idle", false);
                enemieAnimator.SetBool("Whiver", true);
                StartCoroutine(colorEffect(Color.magenta));
                break;


        }
    }

    private IEnumerator colorEffect(Color colourEffe)
    {
        spriteRenderer.color = colourEffe;
       yield return new  WaitForSeconds(0.5f);
        spriteRenderer.color = Color.white;
    }
}