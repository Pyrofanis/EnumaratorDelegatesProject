using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieDeath : MonoBehaviour
{
    private EnemieBehaviourManager enemieBehaviour;
    private Collider2D enemiesCollider;
    private EnemieAnimationManager enemieAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Die()
    {
        yield return new WaitForSeconds(0.2f);
        enemieAnimation.enabled = false;
        enemiesCollider.enabled = false;
        enemieBehaviour.enabled = false;
    }
}
