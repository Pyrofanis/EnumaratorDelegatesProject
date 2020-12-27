using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   [Header("Waves")]
    [Tooltip("through Waves scriptables")]
    [Min(1)]
    public SpawnManagerVariables[] spawnManagers;
    [Header("Waypoints To Instanciate to")]
    [Tooltip("Add all possible Waypoints")]
    [Min(1)]
    public Transform[] wayPoints;


    private int currentEnemiesInSceneIndexer=0;

    private float timeToSpawn, timeTillNextWave;

    private List<GameObject> _CurrentEnemiesActive;

    private int _CurrentWave=0;
    [SerializeField]
    int waypointIndexer = 0;
    [SerializeField]
    int enemyTypeIndexer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PrepareForNextWave();
        CheckAndSpawn();
    }
    private void PrepareForNextWave()
    {
        if (timeTillNextWave >= spawnManagers[_CurrentWave].timeTillNextWave)
        {   
            currentEnemiesInSceneIndexer = 0;
            timeTillNextWave = 0;
            if (_CurrentWave < spawnManagers.Length)
            {
                _CurrentWave++;

            }
        }
    }
    private void CheckAndSpawn()
    {
        if (currentEnemiesInSceneIndexer <= spawnManagers[_CurrentWave].maxEnemies)
        {
            timeToSpawn += Time.deltaTime;
            if (timeToSpawn >= spawnManagers[_CurrentWave].spawnTime)
            {
                StartCoroutine(InstantiateEnemies());
                timeToSpawn = 0;
            }
        }
        else if (EnemiesHaveDied())
        {   
            timeTillNextWave += Time.deltaTime;
        }
    }
    private bool EnemiesHaveDied()
    {
        //switch (_CurrentEnemiesActive.Count)
        //{
        //    case  _CurrentEnemiesActive.Count.Equals(0):
        //        foreach (GameObject enemy in _CurrentEnemiesActive)
        //        {
        //            if (enemy == null)
        //            {
        //                _CurrentEnemiesActive.TrimExcess();
        //            }
        //        }
        //        break;
        //}
        foreach (GameObject enemy in _CurrentEnemiesActive)
        {
            if (enemy == null)
            {
                _CurrentEnemiesActive.TrimExcess();
            }
        }
        if (currentEnemiesInSceneIndexer == spawnManagers[_CurrentWave].maxEnemies&&_CurrentEnemiesActive.Count.Equals(0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void CalculateWhichEnemyToInstanciate()
    {
        if (spawnManagers[_CurrentWave].enemyTypes.Count > 1)
        {
            enemyTypeIndexer = Random.Range(0, spawnManagers[_CurrentWave].enemyTypes.Capacity + 1);
        }
        else
        {
            enemyTypeIndexer = 0;
        }
    }
    private void CalculateWhichWaypointToUse()
    {
        if (spawnManagers[_CurrentWave].wayPoints > 1)
        {
            waypointIndexer = Random.Range(0, spawnManagers[_CurrentWave].wayPoints + 1);
        }
        else
        {
            waypointIndexer = 0;
        }
    }
    IEnumerator InstantiateEnemies()
    {
        

        CalculateWhichEnemyToInstanciate();
        CalculateWhichWaypointToUse();

        GameObject enemy = spawnManagers[_CurrentWave].enemyTypes[enemyTypeIndexer];
        Transform wayPoint = wayPoints[waypointIndexer];

        yield return new WaitForSeconds(0.1f);
        currentEnemiesInSceneIndexer++;
        _CurrentEnemiesActive.Add(Instantiate(enemy, wayPoint.position, Quaternion.identity));

    }
}
