using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Tooltip("players health ")]
    [Header("Players health")]
    [Range(50, 200)]
    public float playerHealth;
    [Tooltip("The SpeedOf The Player i x axes")]
    [Header("Players Speed")]
    [Range(1, 10)]
    public float speed;
    [Tooltip("The Jump Height Of Player")]
    [Header("Players Jump Height")]
    [Range(100, 1000)]
    public float jumpSpeed;
   

    [Header("Prefab Of Bullet/Fist")]
    public GameObject bulletPrefab;

    [HideInInspector]
    public Vector3 boltDirection;

    [Header("AttackRange")]
    [Header("Attack Stats")]
    [Tooltip("maximum attackRangeOfPlayer")]
    [Range(0.5f,2)]
    public float attackRange;

    [Header("Responsivness")]
    [Tooltip("Bassicaly the bolts speed but since it melle that only corresponds to responsiveness")]
    [Range(2,20)]
    public float attackResponsiveness;

    [Header("Attack rate")]
    [Range(0.1f,0.6f)]
    public float attackRate;

    [Tooltip("is going To Be Called by the attackScript")]
    [Header("playersDamage")]
    [Range(10, 80)]
    public float damage;

    [Header("Players Rejuvanation Speed Per Second")]
    [Tooltip("multiplied by delta time")]
    [Range(1,20)]
    public float rejuvanationHpAdd;

    [Header("Damage addition Per Cycle")]
    [Tooltip("It is going to be added at every completed Cycle")]
    [Range(5,20)]
    public int damageAddition;

    private void Start()
    {
        LoadData();
    }
    public void SaveWhatDataNeeded()
    {
        SaveSystem.SaveNeededData(this);
    }
    public void LoadData()
    {
        SaveData data = SaveSystem.LoadData();
        damage += data.playerDmg;
        Spawner.completedCycles = data.currentCompletedCycles;
    }
}
