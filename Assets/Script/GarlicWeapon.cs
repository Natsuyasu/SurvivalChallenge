using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicWeapon : WeaponBase
{
    [SerializeField] float attackAreaSize = 3f;
    //[SerializeField] GameObject MagicPrefab;
    //[SerializeField] GameObject GarlicPrefab;

    /*private void Awake()
    {
        GameObject Garlic = Instantiate(GarlicPrefab);
        Garlic.SetActive(true);
    }*/
    public override void Attack()
    {
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackAreaSize);
        ApplyDamage(colliders);
    }
}
