using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField] StageData StageData;
    [SerializeField] EnemiesManager enemiesManager;

    StageTime StageTime;
    int eventIndex;

    private void Awake()
    {
        StageTime = GetComponent<StageTime>();
    }

    private void Update()
    {
        if (eventIndex >= StageData.stageEvents.Count)
        {
            return;
        }

        if(StageTime.time > StageData.stageEvents[eventIndex].time)
        {
            Debug.Log(StageData.stageEvents[eventIndex].message);

            for (int i = 0; i < StageData.stageEvents[eventIndex].count; i++)
            {
                enemiesManager.SpawnEnemy(StageData.stageEvents[eventIndex].enemyToSpawn);
            }
            

            eventIndex += 1;
        }
    }
}
