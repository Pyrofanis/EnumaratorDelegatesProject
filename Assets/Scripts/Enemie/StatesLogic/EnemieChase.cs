using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieChase : MonoBehaviour
{

    private Vector3 whereToMove;

    private EnemieStats enemieStats;

    private bool startChasing;
    private EnemiesMain enemiesMain;
    private void Awake()
    {
        enemiesMain = GetComponent<EnemiesMain>();

    }
    // Start is called before the first frame update
    void Start()
    {
        enemieStats = GetComponent<EnemieStats>();
        enemiesMain.onEnemieStateChanger += CheckIfIShouldChase;
    }
    private void CheckIfIShouldChase(EnemiesMain.EnemieStates enemie)
    {
        switch (enemie)
        {
            case EnemiesMain.EnemieStates.chase:
                startChasing = true;
                break;
            default:
                startChasing = false;
                break;
        }

    }
    // Update is called once per frame
    void Update()
    {
        Chase(startChasing);
    }
    private void Chase(bool shouldIKeepGoin)
    {
        if (shouldIKeepGoin)
        {
            Vector2 playersPosition = enemieStats.playerStats.transform.position;
            float chaseSpeed = enemieStats.speed * 2;
            enemieStats.enemiesRigidBody.position = Vector2.MoveTowards(transform.position, playersPosition, chaseSpeed * Time.deltaTime);
        }
        
    }
}
