using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public float playerDmg;
    public int currentCompletedCycles;

    public SaveData(PlayerStats player)
    {
        playerDmg = player.damage-30;
        currentCompletedCycles =Mathf.RoundToInt((player.damage - 30) / 10);
    }
}
