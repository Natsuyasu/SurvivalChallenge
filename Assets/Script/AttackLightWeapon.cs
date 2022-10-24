using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLightWeapon : MonoBehaviour
{
    [SerializeField] float timeToAttack;
    float timer;

    PlayerController playerMove;

    [SerializeField] GameObject AttackLightPrefab;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerController>();
    }

    private void Update()
    {
        if (timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }

        timer = 0;

        SpawnAttackLight();

    }

    private void SpawnAttackLight()
    {
        GameObject attackLight = Instantiate(AttackLightPrefab);
        attackLight.transform.position = transform.position;
        attackLight.GetComponent<AttackLightProjectil>().SetDirection(playerMove.lastHorizontalVector, 0f);
    }
}
