using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int level = 1;
    int experience = 0;
    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] UpGradePanelManager UpGradePanel;

    [SerializeField] List<UpGradeData> upGrades;
    List<UpGradeData> selectUpgrades;
    [SerializeField] List<UpGradeData> acquiredUpgrades;

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

    public void Upgrade(int selectedUpgradeID)
    {
        UpGradeData upGradeData = selectUpgrades[selectedUpgradeID];

        if (acquiredUpgrades == null)
        {
            acquiredUpgrades = new List<UpGradeData>();
        }

        acquiredUpgrades.Add(upGradeData);
        upGrades.Remove(upGradeData);
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

        if (selectUpgrades == null)
        {
            selectUpgrades = new List<UpGradeData>();
        }

        selectUpgrades.Clear();
        selectUpgrades.AddRange(GetUpGrades(3));


        UpGradePanel.OpenPanel(selectUpgrades);
        experience -= TO_LEVEL_UP;
        level++;
        experienceBar.SetLevelText(level);
    }

    public List<UpGradeData> GetUpGrades(int count)
    {
        List<UpGradeData> upGradeList = new List<UpGradeData>();

        if (count > upGrades.Count)
        {
            count = upGrades.Count;
        }

        for (int i = 0; i < count; i++)
        {
            upGradeList.Add(upGrades[Random.Range(0, upGrades.Count)]);
        }
        

        return upGradeList;
    }

}
