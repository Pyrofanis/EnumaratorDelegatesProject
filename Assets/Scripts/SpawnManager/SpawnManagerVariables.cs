using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Wave_",menuName ="SpawnManager/Wave",order =0)]
public class SpawnManagerVariables : ScriptableObject
{   [Header("MaxEnemies")]
    [Tooltip("MaxEnemies To Spawn in Current Wave")]
    [Min(1)]
    public int maxEnemies;
    [Header("EnemiesToSpawn")]
    [Tooltip("EnemiesPrefab To Insantiate")]
    [Min(1)]
    public List<GameObject> enemyTypes;
    [Header("Max Waypoints")]
    [Tooltip("Points to instanciate to above 7 are flyingWaypoints")]
    [Range(1,10)]
    public int wayPoints;
    [Header("Next Wave Respawn Time")]
    [Range(5,10)]
    public float timeTillNextWave;
    [Header("TimeTillNextInstantiation")]
    [Range(0.5f,2f)]
    public float spawnTime;
}
