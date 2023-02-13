using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemiesSpawnGroup
{
    public EnemyData enemyData;
    public int count;
    public bool isBoss;
    public float repeatTimer;
    public float timeBetweenSpawns;
    public int repeatCount;

    public EnemiesSpawnGroup(EnemyData enemyData, int count, bool isBoss)
    {
        this.enemyData = enemyData;
        this.count = count;
        this.isBoss = isBoss;
    }

    public void SetRepeatSpawn(float timeBetweenRepeats, int repeatCount)
    {
        this.timeBetweenSpawns = timeBetweenRepeats;
        this.repeatCount = repeatCount;
        repeatTimer = timeBetweenSpawns;
    }
}

public class EnemiesManager : MonoBehaviour
{

    [SerializeField] StageProgress stageProgress;
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnArea;
    //[SerializeField] float spawnTimer;
    GameObject player;

    List<enemyMovement> bossEnemyList;
    int totalBossHealth;
    int currentBossHealth;
    [SerializeField] Slider bossHeathBar;

    List<EnemiesSpawnGroup> enemiesSpawnGroupsList;
    List<EnemiesSpawnGroup> repeatSpawnGroupList;

    int spawnPerFrame = 2;
    
    //[SerializeField] PlayerManager Manager;
    //public GameObject player;
   


    private void Start()
    {
        player = GameManager.instance.playerTransform.gameObject;
        bossHeathBar = FindObjectOfType<BossHPBar>().GetComponent<Slider>();
        bossHeathBar.gameObject.SetActive(false);
        stageProgress = FindObjectOfType<StageProgress>();
    }

    private void Update()
    {
        processSpawn();
        UpdateBossHealth();
        ProcessRepeatedSpawnGroups();
    }

    private void ProcessRepeatedSpawnGroups()
    {
        if (repeatSpawnGroupList == null) { return; }
        for(int i = repeatSpawnGroupList.Count - 1; i >= 0; i--)
        {
            repeatSpawnGroupList[i].repeatTimer -= Time.deltaTime;
            if(repeatSpawnGroupList[i].repeatTimer < 0)
            {
                repeatSpawnGroupList[i].repeatTimer = repeatSpawnGroupList[i].timeBetweenSpawns;
                AddGroupToSpawn(repeatSpawnGroupList[i].enemyData, repeatSpawnGroupList[i].count, repeatSpawnGroupList[i].isBoss);
                repeatSpawnGroupList[i].repeatCount -= 1;
                if(repeatSpawnGroupList[i].repeatCount <= 0)
                {
                    repeatSpawnGroupList.RemoveAt(i);
                }
            }
        } 
    }

    private void processSpawn()
    {
        if(enemiesSpawnGroupsList == null) { return; }

        for(int i = 0; i< spawnPerFrame; i++)
        {
            if (enemiesSpawnGroupsList.Count > 0)
            {
                if (enemiesSpawnGroupsList[0].count <= 0) { return; }
                SpawnEnemy(enemiesSpawnGroupsList[0].enemyData, enemiesSpawnGroupsList[0].isBoss);
                enemiesSpawnGroupsList[0].count -= 1;

                if (enemiesSpawnGroupsList[0].count <= 0)
                {
                    enemiesSpawnGroupsList.RemoveAt(0);
                }
            }
        }
    }

    private void UpdateBossHealth()
    {

        if(bossEnemyList == null) { return; }
        if (bossEnemyList.Count == 0) { return; }


        currentBossHealth = 0;

        for (int i= 0; i < bossEnemyList.Count; i++)
        {
            if (bossEnemyList[i] == null) { continue; }
            currentBossHealth += bossEnemyList[i].stats.hp;
        }

        bossHeathBar.value = currentBossHealth;


        if (currentBossHealth <= 0)
        {
            bossHeathBar.gameObject.SetActive(false);
            bossEnemyList.Clear();
        }

    }

    public void AddRepeatedSpawn(StageEvent stageEvent, bool isBoss)
    {
        EnemiesSpawnGroup repeatSpawnGroup = new EnemiesSpawnGroup(stageEvent.enemyToSpawn, stageEvent.count, isBoss);
        repeatSpawnGroup.SetRepeatSpawn(stageEvent.repeatEverySecs, stageEvent.repeatCount);

        if(repeatSpawnGroupList == null)
        {
            repeatSpawnGroupList = new List<EnemiesSpawnGroup>();
        }

        repeatSpawnGroupList.Add(repeatSpawnGroup);

    }

    public void AddGroupToSpawn(EnemyData enemyToSpawn, int count, bool isBoss)
    {
        EnemiesSpawnGroup NewGroup = new EnemiesSpawnGroup(enemyToSpawn, count, isBoss);

        if(enemiesSpawnGroupsList == null) { enemiesSpawnGroupsList = new List<EnemiesSpawnGroup>(); }
        enemiesSpawnGroupsList.Add(NewGroup);


    }


    public void SpawnEnemy(EnemyData enemyToSpawn, bool isBoss)
    {
        Vector3 position = UtilityTools.GenerateRandomPositionSquarePattern(spawnArea);
        position += player.transform.position;
        GameObject newEnemy = Instantiate(enemyToSpawn.EnemyPrefab);
        newEnemy.transform.position = position;
        enemyMovement newEnemyComponent = newEnemy.GetComponent<enemyMovement>();
        newEnemyComponent.SetTarget(player);
        newEnemyComponent.SetStats(enemyToSpawn.stats);
        newEnemyComponent.UpdateStatsForProgress(stageProgress.progress);

        if(isBoss == true)
        {
            SpawnBossEnemy(newEnemyComponent);
        }

        newEnemy.transform.parent = transform;
    }

    private void SpawnBossEnemy(enemyMovement newBoss)
    {
        if(bossEnemyList == null) { bossEnemyList = new List<enemyMovement>(); }

        bossEnemyList.Add(newBoss);

        totalBossHealth += newBoss.stats.hp;

        bossHeathBar.gameObject.SetActive(true);
        bossHeathBar.maxValue = totalBossHealth;
    }
}
