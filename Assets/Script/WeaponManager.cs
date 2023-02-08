﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponObjectsContainer;
    [SerializeField] WeaponData startingWeapon;
    List<WeaponBase> weapons;
    Character character;

    private void Awake()
    {
        weapons = new List<WeaponBase>();
        character = GetComponent<Character>();
    }

    private void Start()
    {
        AddWeapon(startingWeapon);
    }

    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectsContainer);

        WeaponBase weaponBase = weaponGameObject.GetComponent<WeaponBase>();

        weaponBase.SetData(weaponData);
        weapons.Add(weaponBase);
        weaponBase.AddOwner(character);


        Level level = GetComponent<Level>();
        if (level != null)
        {
            level.AddUpgradesIntoTheListOfAvailableUpgrades(weaponData.upGrades);
        }
    }

    internal void UpgradeWeapon(UpGradeData upGradeData)
    {
        WeaponBase weaponToUpgrade = weapons.Find(wd => wd.weaponData == upGradeData.weaponData);
        weaponToUpgrade.Upgrade(upGradeData);
    }
}
