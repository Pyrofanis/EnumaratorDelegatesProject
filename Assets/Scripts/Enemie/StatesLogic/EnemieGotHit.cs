using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieGotHit : MonoBehaviour
{
    private EnemieStats enemieStats;
    private EnemiesMain enemiesMain;
    private void Awake()
    {
        enemiesMain = GetComponent<EnemiesMain>();

    }
    // Start is called before the first frame update
    void Start()
    {
        enemieStats = GetComponent<EnemieStats>();
        enemiesMain.onEnemieStateChanger += CheckIfGotHitAndApply;
    }
    private void CheckIfGotHitAndApply(EnemiesMain.EnemieStates enemieState)
    {
        if (enemieState.Equals(EnemiesMain.EnemieStates.gotHit))
        {
            GotHit();
        }
    }
    void GotHit()
    {
        enemieStats.health -= enemieStats.playerStats.damage;
    }
}
