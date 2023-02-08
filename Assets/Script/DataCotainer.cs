using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum PlayerPersistantUpgrade
{
    HP,
    Damage
}

[Serializable] 
public class PlayerUpgrades
{
    public PlayerPersistantUpgrade persistantUpgrade;
    public int level = 0;
    public int max_level = 15;
    public int CostToUpgrade = 100;
}

[CreateAssetMenu]
public class DataCotainer : ScriptableObject
{
    public int coins;

    public List<bool> stageCompletion;

    public List<PlayerUpgrades> upgrades;

    public void stageComplete(int i)
    {
        stageCompletion[i] = true;
    }

    internal int GetUpgradeLevel(PlayerPersistantUpgrade PersistantUpgrade)
    {
        return upgrades[(int)PersistantUpgrade].level;
    }
}
