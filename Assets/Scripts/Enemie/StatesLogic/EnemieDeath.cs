using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieDeath : MonoBehaviour
{ 
    [Header("DespawnTime")]
    public float timeToDespawn=1f;

    private EnemieBehaviourManager enemieBehaviour;
    private EnemieCollisionsBehaviourManager enemieCollisionsBehaviour;
    private Collider2D enemiesCollider;
    private EnemieAnimationManager enemieAnimation;
    private Rigidbody2D enemieRb;


    private EnemiesMain enemiesMain;
    private void Awake()
    {
        enemieAnimation = GetComponent<EnemieAnimationManager>();
        enemiesCollider = GetComponent<Collider2D>();
        enemieBehaviour = GetComponent<EnemieBehaviourManager>();
        enemieCollisionsBehaviour = GetComponent<EnemieCollisionsBehaviourManager>();
        enemieRb = GetComponent<Rigidbody2D>();
        enemiesMain = GetComponent<EnemiesMain>();

    }
    // Start is called before the first frame update
    void Start()
    {  
        enemiesMain.onEnemieStateChanger += Die;
    }

  private void Die(EnemiesMain.EnemieStates states)
    {
        if (states.Equals(EnemiesMain.EnemieStates.death))
        {
            StartCoroutine(Death());
        }
    }
    private IEnumerator Death()
    {
        Spawner.deadEnemies++;
        enemieRb.constraints = RigidbodyConstraints2D.FreezeAll;
        enemiesCollider.enabled = false;
        enemieBehaviour.enabled = false;
        enemieCollisionsBehaviour.enabled = false;
        yield return new WaitForSeconds(0.2f);
        enemieAnimation.enabled = false;
        StartCoroutine(Destroy());
    }
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(timeToDespawn);
        Destroy(gameObject);
    }
}
