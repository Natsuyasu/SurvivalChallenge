using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponStates
{
    public int damage;
    public float timeToAttack;

    public WeaponStates(int damage, float timeToAttack)
    {
        this.damage = damage;
        this.timeToAttack = timeToAttack;
    }
}


[CreateAssetMenu]

public class WeaponData : ScriptableObject
{
    public string Name;
    public WeaponStates stats;
    public GameObject weaponBasePrefab;
}
