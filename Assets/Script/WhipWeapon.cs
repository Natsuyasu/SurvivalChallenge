using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : WeaponBase
{
    [SerializeField] GameObject leftWhip;
    [SerializeField] GameObject rightWhip;
    PlayerController playerController;

    [SerializeField] Vector2 attackSize = new Vector2(4f, 2f);
    

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
    }
    
    

    public override void Attack()
    {
        StartCoroutine(AttackProcess());
    }

    IEnumerator AttackProcess()
    {
        for(int i = 0; i< weaponStates.numberOfAttack; i++)
        {
            if (playerController.lastHorizontalDeCoupledVector > 0)
            {
                rightWhip.SetActive(true);
                Debug.Log("whip active");
                Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhip.transform.position, attackSize, 0f);
                ApplyDamage(colliders);

            }
            if (playerController.lastHorizontalDeCoupledVector < 0)
            {
                rightWhip.SetActive(true);
                Debug.Log("whip active");
                Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhip.transform.position, attackSize, 0f);
                ApplyDamage(colliders);

            }
            yield return new WaitForSeconds(0.4f);
        }
        
    }
}
