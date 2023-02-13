using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField] StageData StageData;
    EnemiesManager enemiesManager;

    StageTime StageTime;
    int eventIndex;
    PlayerWinManager PlayerWin;

    private void Awake()
    {
        StageTime = GetComponent<StageTime>();
    }

    private void Start()
    {
        PlayerWin = FindObjectOfType<PlayerWinManager>();
        enemiesManager = FindObjectOfType<EnemiesManager>();
        
    }

    private void Update()
    {
        if (eventIndex >= StageData.stageEvents.Count)
        {
            return;
        }

        if(StageTime.time > StageData.stageEvents[eventIndex].time)
        {
            switch (StageData.stageEvents[eventIndex].eventType)
            {
                case StageEventType.SpawnEnemy:
                    //for (int i = 0; i < StageData.stageEvents[eventIndex].count; i++){ }
                    SpawnEnemy(false);
                    break;
                case StageEventType.SpawnObject:
                    //for (int i = 0; i < StageData.stageEvents[eventIndex].count; i++) { }
                    SpawnObject();

                    break;

                case StageEventType.WinStage:
                    WinStage();

                    break;


                case StageEventType.SpawnEnemyBoss:
                    SpawnEnemyBoss();
                    break;
            }

            Debug.Log(StageData.stageEvents[eventIndex].message);

            eventIndex += 1;
        }
    }

    private void SpawnEnemyBoss()
    {
        SpawnEnemy(true);
        //enemiesManager.SpawnEnemy(StageData.stageEvents[eventIndex].enemyToSpawn, true);
    }

    private void WinStage()
    {
        PlayerWin.Win();
    }

    private void SpawnEnemy(bool Boss)
    {
        StageEvent currentEvent = StageData.stageEvents[eventIndex];
        enemiesManager.AddGroupToSpawn(currentEvent.enemyToSpawn, currentEvent.count, Boss);

        /*for (int i = 0; i < StageData.stageEvents[eventIndex].count; i++) 
        {
            enemiesManager.SpawnEnemy(StageData.stageEvents[eventIndex].enemyToSpawn, Boss);
        }*/

        if(currentEvent.isRepeatedEvent == true)
        {
            enemiesManager.AddRepeatedSpawn(currentEvent,Boss);        
        }
        
    }

    private void SpawnObject()
    {
        for (int i = 0; i < StageData.stageEvents[eventIndex].count; i++) {
            Vector3 positionToSpawn = GameManager.instance.playerTransform.position;
            positionToSpawn += UtilityTools.GenerateRandomPositionSquarePattern(new Vector2(5f, 5f));

            SpawnManager.instance.SpawnObjct(positionToSpawn, StageData.stageEvents[eventIndex].objectToSpawn);
        }
        
    }
}
