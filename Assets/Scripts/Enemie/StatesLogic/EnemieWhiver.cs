using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieWhiver : MonoBehaviour
{
    private EnemiesMain enemiesMain;
    private EnemieStats enemieStats;

    private bool StartRejuvanating;
    private void Awake()
    {
        enemieStats = GetComponent<EnemieStats>();
        enemiesMain = GetComponent<EnemiesMain>();
    }
    // Start is called before the first frame update
    void Start()
    {
        enemiesMain.onEnemieStateChanger += CheckAndApplyRejuvanation;
    }
    private void CheckAndApplyRejuvanation (EnemiesMain.EnemieStates state)
    {
        if (state.Equals(EnemiesMain.EnemieStates.whiver))
        {
            StartRejuvanating = true;
        }
        else
        {
            StartRejuvanating = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rejuvanation(StartRejuvanating);
    }
    private void Rejuvanation(bool rejuvanate)
    {
        if (rejuvanate)
        {
            enemieStats.health += enemieStats.rateOfRejuvanation*Time.deltaTime;
        }
    }
}
