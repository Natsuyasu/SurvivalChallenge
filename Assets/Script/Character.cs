using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHP = 1000;
    public int currentHP = 1000;
    [SerializeField] StatusBar hpBar;

    [HideInInspector] public Level level;
    [HideInInspector] public Coins coins;


    private void Awake()
    {
        level = GetComponent<Level>();
        coins = GetComponent<Coins>();
    }

    private void Start()
    {
        hpBar.SetState(currentHP, maxHP);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if(currentHP <= 0)
        {
            Debug.Log("Game Over");
        }
        hpBar.SetState(currentHP, maxHP);

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
