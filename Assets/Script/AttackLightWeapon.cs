using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLightWeapon : WeaponBase
{
    PlayerController playerMove;

    [SerializeField] GameObject AttackLightPrefab;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerController>();
    }

    

    
    public override void Attack()
    {
        GameObject attackLight = Instantiate(AttackLightPrefab);
        attackLight.transform.position = transform.position;
        attackLight.GetComponent<AttackLightProjectil>().SetDirection(playerMove.lastHorizontalVector, 0f);
    
}
}
