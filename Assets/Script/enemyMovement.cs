using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyStats
{
    public int hp = 99;
    public int damage = 1;
    public int experienceReward = 400;
    public float speed = 1f;
    

    public EnemyStats(EnemyStats stats)
    {
        this.hp = stats.hp;
        this.damage = stats.damage;
        this.experienceReward = stats.experienceReward;
        this.speed = stats.speed;
    }

    internal void ApplyProgress(float progress)
    {
        this.hp = (int)(hp * progress);
        this.damage = (int)(damage * progress);
    }
}

public class enemyMovement : MonoBehaviour, IDamageable
{
    public Rigidbody2D EnemyRB;
    
    public GameObject targetGameObject;
    
    Transform targetDestination;
    Character targetCharacter;

    public EnemyStats stats;

    private void Awake()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
        //targetGameObject = targetDestination.gameObject;
    }



    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;

    }

    internal void UpdateStatsForProgress(float progress)
    {
        stats.ApplyProgress(progress);
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        //MoveMent();
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        EnemyRB.velocity = direction * stats.speed * Time.deltaTime;
        transform.localScale = new Vector3(-(targetDestination.position.x - transform.position.x) / Mathf.Abs(targetDestination.position.x - transform.position.x), 1, 1);
    }

    internal void SetStats(EnemyStats stats)
    {
        this.stats = new EnemyStats(stats);
    }

    /*void MoveMent()
    {
        var playerPosition = Manager.position;
        var enemyPosition = (Vector2)transform.position;
        var direction = playerPosition - enemyPosition;
        direction.Normalize();
        transform.Translate(direction.normalized * Time.deltaTime * speed, Space.World);
        transform.localScale = new Vector3(-(playerPosition.x - enemyPosition.x)/Mathf.Abs(playerPosition.x - enemyPosition.x), 1, 1);
        //var targetPosition = enemyPosition + direction;
        //Vector3.MoveTowards(enemyPosition, targetPosition, speed);

    }*/

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            Attack();

        }

    }

    private void Attack()
    {
        //Debug.Log("Attacked!");
        if (targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }
        targetCharacter.TakeDamage(stats.damage);

    }

    public void TakeDamage(int damage)
    {
        stats.hp -= damage;
        if (stats.hp < 1)
        {
            targetGameObject.GetComponent<Level>().AddExperience(stats.experienceReward);
            GetComponent<DropOnDestroy>().CheckDrop();
            Destroy(gameObject);
        }
    }

}
