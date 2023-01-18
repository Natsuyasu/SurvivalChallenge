using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponStates
{
    public int damage;
    public float timeToAttack;
    public int numberOfAttack;

    public WeaponStates(int damage, float timeToAttack, int numberOfAttack)
    {
        this.damage = damage;
        this.timeToAttack = timeToAttack;
        this.numberOfAttack = numberOfAttack;
    }

    internal void Sum(WeaponStates weaponUpgradeStates)
    {
        this.damage += weaponUpgradeStates.damage;
        this.timeToAttack += weaponUpgradeStates.timeToAttack;
        this.numberOfAttack += weaponUpgradeStates.numberOfAttack;
    }
}


[CreateAssetMenu]

public class WeaponData : ScriptableObject
{
    public string Name;
    public WeaponStates stats;
    public GameObject weaponBasePrefab;
    public List<UpGradeData> upGrades;
}
