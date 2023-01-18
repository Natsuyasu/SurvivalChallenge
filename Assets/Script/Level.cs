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

    WeaponManager weaponManager;
    PassiveItems PassiveItems;

    [SerializeField] List<UpGradeData> upgradesAvaliableStart;

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
        PassiveItems = GetComponent<PassiveItems>();
    }

    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    internal void AddUpgradesIntoTheListOfAvailableUpgrades(List<UpGradeData> upgradesToAdd)
    {
        if(upgradesToAdd == null)
        {
            return;
        }
        this.upGrades.AddRange(upgradesToAdd);
    }

    private void Start()
    {
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
        AddUpgradesIntoTheListOfAvailableUpgrades(upgradesAvaliableStart);
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
        switch (upGradeData.upGradeType)
        {
            case UpGradeType.WeaponUpgrade:
                weaponManager.UpgradeWeapon(upGradeData);
                break;
            case UpGradeType.ItemUpGrade:
                PassiveItems.UpgradeItem(upGradeData);
                break;
            case UpGradeType.WeaponUnlock:
                weaponManager.AddWeapon(upGradeData.weaponData);
                break;
            case UpGradeType.ItemUnlock:
                PassiveItems.Equip(upGradeData.item);
                AddUpgradesIntoTheListOfAvailableUpgrades(upGradeData.item.upGrades);
                break;
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
