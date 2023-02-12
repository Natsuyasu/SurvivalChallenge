using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : WeaponBase
{
    [SerializeField] GameObject BulletPrefab;

    public override void Attack()
    {
        UpdateVectorOfAttack();
        for (int i = 0; i < weaponStates.numberOfAttack; i++)
        {
            GameObject attackLight = Instantiate(BulletPrefab);

            Vector3 newPosition = transform.position;

            attackLight.transform.position = newPosition;
            AttackLightProjectil attackLightProjectil = attackLight.GetComponent<AttackLightProjectil>();
            attackLightProjectil.SetDirection(vectorOfAttack.x, vectorOfAttack.y);
            //attackLightProjectil.SetDirection(playerMove.lastHorizontalVector, newPosition.y);
            attackLightProjectil.damage = GetDamage();
        }
    }
}
