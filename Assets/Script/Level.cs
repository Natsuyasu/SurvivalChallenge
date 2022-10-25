﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int level = 1;
    int experience = 0;
    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] UpGradePanelManager UpGradePanel;

    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    private void Start()
    {
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUP();
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    public void CheckLevelUP()
    {
        if (experience >= TO_LEVEL_UP)
        {
            LevelUP();
        }
    }

    private void LevelUP()
    {
        UpGradePanel.OpenPanel();
        experience -= TO_LEVEL_UP;
        level++;
        experienceBar.SetLevelText(level);
    }
}
