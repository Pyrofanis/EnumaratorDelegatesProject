using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Waves")]
    [Tooltip("through Waves scriptables")]
    [Min(1)]
    public SpawnManagerVariables[] spawnManagers;

    [Header("Waypoints To Instanciate to")]
    [Tooltip("Add all possible Waypoints")]
    [Min(1)]
    public Transform[] wayPoints;

    private List<GameObject> _CurrentEnemiesActive;



    private int currentEnemiesInSceneIndexer = 0;
    [SerializeField]
    private int _CurrentWave;


    private float timeToSpawn;

    [HideInInspector]
    public static float timeTillNextWave;
    [HideInInspector]//used By Text Indicator
    public static float _TimeToIndicateAtText;

    [HideInInspector]
    public static int deadEnemies;

    [HideInInspector]
    public static int completedCycles;

    
    private PlayerStats playerStats;



    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.FindObjectOfType<PlayerStats>();
        _CurrentWave = 0;
        completedCycles = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PrepareForNextWave();
        CheckAndSpawn();
        TimeToIndicateCalculate();
    }
    private void TimeToIndicateCalculate()
    {
        _TimeToIndicateAtText = spawnManagers[_CurrentWave].timeTillNextWave - timeTillNextWave;
    }
    private void PrepareForNextWave()
    {
        if (timeTillNextWave >= spawnManagers[_CurrentWave].timeTillNextWave)
        {
            StartCoroutine(PrepareNextWave());


        }
    }
    private void CheckAndSpawn()
    {
        if (currentEnemiesInSceneIndexer < spawnManagers[_CurrentWave].maxEnemies)
        {
            timeToSpawn += Time.deltaTime;
            if (timeToSpawn >= spawnManagers[_CurrentWave].spawnTime)
            {
                timeToSpawn = 0;
                StartCoroutine(InstantiateEnemies());
            }
        }
        if (EnemiesHaveDied())
        {
            timeTillNextWave += Time.deltaTime;
        }
    }
    private bool EnemiesHaveDied()
    {
        if (deadEnemies >= spawnManagers[_CurrentWave].maxEnemies)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool ShouldIncrease_CurrentWaveIndex()
    {
        if (_CurrentWave < spawnManagers.Length - 1)
        {
            return true;

        }
        else
        {
            return false;
        }
    }

    private int CalculatedWhichEnemyToInstanciate()
    {
        if (spawnManagers[_CurrentWave].enemyTypes.Count > 1)
        {
            return Random.Range(0, spawnManagers[_CurrentWave].enemyTypes.Count);
        }
        else
        {
            return 0;
        }
    }
    private int CalculatedWhichWaypointToUse()
    {
        if (spawnManagers[_CurrentWave].wayPoints > 1)
        {
            return Random.Range(0, spawnManagers[_CurrentWave].wayPoints + 1);
        }
        else
        {
            return 0;
        }
    }
    private void ACycleEnded()
    {
        _CurrentWave = 0;
        completedCycles++;
        playerStats.damage += playerStats.damageAddition;
    }
    IEnumerator PrepareNextWave()
    {
        if (ShouldIncrease_CurrentWaveIndex())
        {
            _CurrentWave++;
        }
        else
        {
            ACycleEnded();
        }
            deadEnemies = 0;
            currentEnemiesInSceneIndexer = 0;
            timeTillNextWave = 0.0f;
            yield return new WaitForSeconds(0.1f);
            _CurrentEnemiesActive.Clear();
      
    }
    IEnumerator InstantiateEnemies()
    {
        GameObject enemy = spawnManagers[_CurrentWave].enemyTypes[CalculatedWhichEnemyToInstanciate()];
        Transform wayPoint = wayPoints[CalculatedWhichWaypointToUse()];

        yield return new WaitForSeconds(0.1f);

        currentEnemiesInSceneIndexer++;
        _CurrentEnemiesActive.Add(Instantiate(enemy, wayPoint.position, Quaternion.Euler(enemy.transform.rotation.eulerAngles)));

    }
}
