using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour, IDamageable
{
    public Rigidbody2D EnemyRB;
    public float speed;
    
    public GameObject targetGameObject;
    
    Transform targetDestination;
    Character targetCharacter;

    [SerializeField] int hp = 99;
    [SerializeField] int damage = 1;
    [SerializeField] int experienceReward = 400;

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



    // Update is called once per frame
    void FixedUpdate()
    {
        //MoveMent();
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        EnemyRB.velocity = direction * speed * Time.deltaTime;
        transform.localScale = new Vector3(-(targetDestination.position.x - transform.position.x) / Mathf.Abs(targetDestination.position.x - transform.position.x), 1, 1);
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
        Debug.Log("Attacked!");
        if (targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }
        targetCharacter.TakeDamage(damage);

    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp < 1)
        {
            targetGameObject.GetComponent<Level>().AddExperience(experienceReward);
            Destroy(gameObject);
        }
    }

}
