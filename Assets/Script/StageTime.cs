using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTime : MonoBehaviour
{
    public float time;
    TimeUI timeUI;

    private void Awake()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        timeUI = FindObjectOfType<TimeUI>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        timeUI.UpdateTime(time);
    }
}
