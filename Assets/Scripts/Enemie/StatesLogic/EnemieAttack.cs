using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieAttack : MonoBehaviour
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
        enemiesMain.onEnemieStateChanger += CheckAndApllyAttack;
    }
    private void CheckAndApllyAttack(EnemiesMain.EnemieStates state)
    {
        if (state.Equals(EnemiesMain.EnemieStates.attack))
        {
            attack();
        }

    }

    private void attack()
    {
            
        enemieStats.playerStats.playerHealth -= enemieStats.dmg;
    }
}
