using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Wave_",menuName ="SpawnManager/Wave",order =0)]
public class SpawnManagerVariables : ScriptableObject
{   [Header("MaxEnemies")]
    [Tooltip("MaxEnemies To Spawn in Current Wave")]
    public int maxEnemies;
    [Header("EnemiesToSpawn")]
    [Tooltip("EnemiesPrefab To Insantiate")]
    public List<GameObject> enemyTypes;
    [Header("Waypoints")]
    [Tooltip("Points to instanciate to")]
    public Transform[] wayPoints;
}
