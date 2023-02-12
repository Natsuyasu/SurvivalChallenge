using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DiractionOfAttack
{
    None,
    Forward,
    LR,
    UpDown
}
public abstract class WeaponBase : MonoBehaviour
{
    PlayerController playerMovement;
    public WeaponData weaponData;

    public WeaponStates weaponStates;

    public float timeToAttack = 1f;
    float timer;

    Character wielder;
    public Vector2 vectorOfAttack;
    [SerializeField] DiractionOfAttack attackDirection;

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerController>();
    }

    public void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0f)
        {
            Attack();
            timer = weaponStates.timeToAttack;
        }

    }

    public void ApplyDamage(Collider2D[] colliders)
    {
        int damage = GetDamage();
        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log(colliders[i].gameObject.name);
            IDamageable e = colliders[i].GetComponent<IDamageable>();
            if (e != null)
            {

                PostDamage(damage, colliders[i].transform.position);
                e.TakeDamage(damage);
            }

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

    public void UpdateVectorOfAttack()
    {
        if(attackDirection == DiractionOfAttack.None)
        {
            vectorOfAttack = Vector2.zero;
            return;
        }
        switch (attackDirection)
        {
            case DiractionOfAttack.Forward:
                vectorOfAttack.x = playerMovement.lastHorizontalCoupledVector;
                vectorOfAttack.y = playerMovement.lastVerticalCoupledVector;
                break;
            case DiractionOfAttack.LR:
                vectorOfAttack.x = playerMovement.lastHorizontalCoupledVector;
                vectorOfAttack.y = 0f;
                break;
            case DiractionOfAttack.UpDown:
                vectorOfAttack.x = 0f;
                vectorOfAttack.y = playerMovement.lastVerticalCoupledVector;
                break;
        }
        vectorOfAttack = vectorOfAttack.normalized;
    }


}
