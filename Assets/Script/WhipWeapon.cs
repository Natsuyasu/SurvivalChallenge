using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    [SerializeField]float timeToAttack = 4f;
    float timer;
    [SerializeField] GameObject leftWhip;
    [SerializeField] GameObject rightWhip;
    PlayerController playerController;

    [SerializeField] Vector2 whipAttackSize = new Vector2(4f, 2f);
    [SerializeField] int whipDamage = 1;

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }


    }

    private void Attack()
    {
        
        timer = timeToAttack;

        if(playerController.lastHorizontalVector > 0)
        {
            rightWhip.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhip.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
            
        }
        if (playerController.lastHorizontalVector < 0)
        {
            rightWhip.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhip.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
            
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log(colliders[i].gameObject.name);
            IDamageable e = colliders[i].GetComponent<IDamageable>();
            if (e != null)
            {
                e.TakeDamage(whipDamage);
            }
            
        }
    }
}
