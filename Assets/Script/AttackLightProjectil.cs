using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLightProjectil : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float speed;
    public int damage = 5;
    public int numOfHits = 1;

    List<IDamageable> enemiesHit;

    float ttl = 6f;

    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y);

        if (dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Time.frameCount % 6 == 0)
        {
            HitDetection();
        }

        Timer();

    }

    private void Timer()
    {
        ttl -= Time.deltaTime;
        if (ttl < 0f)
        {
            Destroy(gameObject);
        }
    }

    private void HitDetection()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        foreach (Collider2D c in hit)
        {
            if(numOfHits > 0)
            {
                IDamageable enemy = c.GetComponent<IDamageable>();
                if (enemy != null)
                {
                    if (CheckRepeatHit(enemy) == false)
                    {
                        PostDamageMessage(damage, transform.position);
                        enemiesHit.Add(enemy);
                        enemy.TakeDamage(damage);
                        numOfHits -= 1;
                    }
                }
            }
            else
            {
                break;
            }
        }

        if (numOfHits <= 0)
        {
            Destroy(gameObject);
        }
    }

    private bool CheckRepeatHit(IDamageable enemy)
    {
        if(enemiesHit == null)
        {
            enemiesHit = new List<IDamageable>();
        }
        return enemiesHit.Contains(enemy);
    }

    private void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void PostDamageMessage(int damage, Vector3 position)
    {
        MessageSystem.instance.PostMessage(damage.ToString(), position);
    }

}
