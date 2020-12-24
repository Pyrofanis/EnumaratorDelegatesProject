using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieCollisionsBehaviourManager : MonoBehaviour
{
    private EnemiesMain enemiesMain;
    private EnemieStats enemieStats;

    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        enemiesMain = GetComponent<EnemiesMain>();
        enemieStats = GetComponent<EnemieStats>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.attack);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && timer >= enemieStats.attackRate)
        {
            enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.attack);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundaries"))
        {
            enemiesMain.ChangeEnemieState(EnemiesMain.EnemieStates.idle);
        }

    }
}
