using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplition : MonoBehaviour
{
    [SerializeField] float timeToComplete;

    StageTime stageTime;
    PauseManager PauseManager;

    [SerializeField] GameObject levelCompletePanel;

    private void Awake()
    {
        
        stageTime = GetComponent<StageTime>();
        PauseManager = FindObjectOfType<PauseManager>();
        levelCompletePanel = FindGameObject("GameWinPanel");
    }

    public void Update()
    {
        if (stageTime.time > timeToComplete)
        {
            PauseManager.PauseGame();
            levelCompletePanel.gameObject.SetActive(true);
        }
    }

    public GameObject FindGameObject(string str)
    {
        GameObject instance = new GameObject();
        var all = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject item in all)
        {
            if (item.gameObject.name == str)
            {
                instance = item;
            }
        }
        return instance;
    }

}
