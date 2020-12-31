using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieAnimationManager : MonoBehaviour
{
    private Animator enemieAnimator;
    private SpriteRenderer spriteRenderer;

    private bool initialFlipValue;

    private EnemiesMain enemiesMain;

    private Color initialColour;

    private void Awake()
    {
        enemieAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemiesMain = GetComponent<EnemiesMain>();
    }
    // Start is called before the first frame update
    void Start()
    {

        initialColour = spriteRenderer.color;
        initialFlipValue = spriteRenderer.flipX;
        enemiesMain.onEnemieStateChanger += ApplyAnimations;
        enemiesMain.onEnemieDirectionChange += ApplyDirectionIndication;
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
    private void ApplyDirectionIndication(EnemiesMain.EnemieDirection direction)
    {
        switch (direction)
        {
            case EnemiesMain.EnemieDirection.right:
                spriteRenderer.flipX = CalculateWhenToFlip();
                break;
            case EnemiesMain.EnemieDirection.left:
                spriteRenderer.flipX = !CalculateWhenToFlip();
                break;
        }
    }
    private bool CalculateWhenToFlip()
    {
        if (initialFlipValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator colorEffect(Color colourEffe)
    {
        spriteRenderer.color = colourEffe;
       yield return new  WaitForSeconds(0.5f);
        spriteRenderer.color = initialColour;
    }
}
