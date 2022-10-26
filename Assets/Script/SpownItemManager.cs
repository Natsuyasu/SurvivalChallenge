using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownItemManager : MonoBehaviour
{
    [SerializeField] GameObject Item;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;
    GameObject player;
    [SerializeField] [Range(0f, 1f)] float probability;
    //[SerializeField] PlayerManager Manager;
    //public GameObject player;
    float timer;

    private void Start()
    {
        player = GameManager.instance.playerTransform.gameObject;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if ((timer < 0f) && (UnityEngine.Random.value < probability))
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();
        position += player.transform.position;
        GameObject newEnemy = Instantiate(Item);
        newEnemy.transform.position = position;
        newEnemy.transform.parent = transform;
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();
        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.x = spawnArea.x * f;
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
        }

        position.z = 0;
        return position;
    }
}
