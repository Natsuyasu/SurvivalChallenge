using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLightWeapon : WeaponBase
{
    PlayerController playerMove;

    [SerializeField] GameObject AttackLightPrefab;
    [SerializeField] float spread;
    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerController>();
    }

    

    
    public override void Attack()
    {
        

        for (int i = 0; i < weaponStates.numberOfAttack; i++)
        {
            GameObject attackLight = Instantiate(AttackLightPrefab);

            Vector3 newPosition = transform.position;

            if (weaponStates.numberOfAttack > 1)
            {
                newPosition.y -= (spread * (weaponStates.numberOfAttack -1)) / 2;
                newPosition.y += i * spread;
            }

            attackLight.transform.position = newPosition;
            AttackLightProjectil attackLightProjectil = attackLight.GetComponent<AttackLightProjectil>();
            attackLightProjectil.SetDirection(playerMove.lastHorizontalVector, 0f);
            //attackLightProjectil.SetDirection(playerMove.lastHorizontalVector, newPosition.y);
            attackLightProjectil.damage = weaponStates.damage;
        }
        
    
}
}
