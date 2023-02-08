using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{

    public WeaponData weaponData;

    public WeaponStates weaponStates;

    public float timeToAttack = 1f;
    float timer;

    Character wielder;

    public void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0f)
        {
            Attack();
            timer = weaponStates.timeToAttack;
        }

    }

    public virtual void SetData(WeaponData wd)
    {
        weaponData = wd;
        timeToAttack = weaponData.stats.timeToAttack;

        weaponStates = new WeaponStates(wd.stats.damage, wd.stats.timeToAttack, wd.stats.numberOfAttack);
    }

    public abstract void Attack();
    
    public int GetDamage()
    {
        int damage = (int)(weaponData.stats.damage * wielder.damageBouns);
        return damage;
    }

    public virtual void PostDamage(int damage, Vector3 targetPosition)
    {
        MessageSystem.instance.PostMessage(damage.ToString(), targetPosition);
    }

    internal void AddOwner(Character charater)
    {
        wielder = charater;
    }

    public void Upgrade(UpGradeData upGradeData)
    {
        weaponStates.Sum(upGradeData.weaponUpgradeStates);
    }
}
