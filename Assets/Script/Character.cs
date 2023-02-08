using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHP = 1000;
    public int currentHP = 1000;

    public int armor = 0;

    public float hpRehenerationRate = 1f;
    public float hpRegenerationTimer;

    public float damageBouns;


    [SerializeField] StatusBar hpBar;

    [HideInInspector] public Level level;
    [HideInInspector] public Coins coins;
    private bool isDead;

    [SerializeField] DataCotainer dataCotainer;


    private void Awake()
    {
        level = GetComponent<Level>();
        coins = GetComponent<Coins>();
    }

    private void Start()
    {

        ApplyPersistantUpgrade();
        hpBar.SetState(currentHP, maxHP);
    }

    private void ApplyPersistantUpgrade()
    {
        int HpUpgradeLevel = dataCotainer.GetUpgradeLevel(PlayerPersistantUpgrade.HP);

        maxHP += maxHP / 10 * HpUpgradeLevel;
        

        int damageUpgradeLevel = dataCotainer.GetUpgradeLevel(PlayerPersistantUpgrade.Damage);

        damageBouns = 1f + 0.1f * damageUpgradeLevel;

    }

    private void Update()
    {
        hpRegenerationTimer += Time.deltaTime * hpRehenerationRate;

        if (hpRegenerationTimer > 1f)
        {
            Heal(1);
            hpRegenerationTimer -= 1f;
        }
    }

    public void TakeDamage(int damage)
    {
        if(isDead == true) { return; }

        ApplyArmor(ref damage);

        currentHP -= damage;

        if(currentHP <= 0)
        {
            GetComponent<CharacterGameOver>().GameOver();
            isDead = true;
        }
        hpBar.SetState(currentHP, maxHP);

    }

    private void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if (damage < 0) { damage = 0; }
    }

    public void Heal(int x)
    {
        if (currentHP <= 0) { return; }
        currentHP += x;
        if (currentHP >= maxHP)
        {
            currentHP = maxHP;
        }
        hpBar.SetState(currentHP, maxHP);
    }


}
