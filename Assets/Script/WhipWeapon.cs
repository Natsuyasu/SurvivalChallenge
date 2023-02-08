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
    
    private void ApplyDamage(Collider2D[] colliders)
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

    public override void Attack()
    {
        StartCoroutine(AttackProcess());
    }

    IEnumerator AttackProcess()
    {
        for(int i = 0; i< weaponStates.numberOfAttack; i++)
        {
            if (playerController.lastHorizontalVector > 0)
            {
                rightWhip.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhip.transform.position, attackSize, 0f);
                ApplyDamage(colliders);

            }
            if (playerController.lastHorizontalVector < 0)
            {
                rightWhip.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhip.transform.position, attackSize, 0f);
                ApplyDamage(colliders);

            }
            yield return new WaitForSeconds(0.3f);
        }
        
    }
}
