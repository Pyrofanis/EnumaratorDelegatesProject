using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieDirectionManager : MonoBehaviour
{
    private EnemiesMain enemiesMain;
    private EnemieStats enemieStats;
    // Start is called before the first frame update
    void Start()
    {
        enemieStats = GetComponent<EnemieStats>();
        enemiesMain = GetComponent<EnemiesMain>();
    }

    // Update is called once per frame
    void Update()
    {
        DirectionManage();
    }
    private void DirectionManage()
    {
        float playersHorizontalPosition = enemieStats.playerStats.transform.position.x;
        float distanceBettweenPlayerAndEnemie = transform.position.x - playersHorizontalPosition;
        if (distanceBettweenPlayerAndEnemie > 0)
        {
            enemiesMain.ChangeDirection(EnemiesMain.EnemieDirection.right);
        }
        else if (distanceBettweenPlayerAndEnemie != 0)
        {
            enemiesMain.ChangeDirection(EnemiesMain.EnemieDirection.left);

        }
    }
}
