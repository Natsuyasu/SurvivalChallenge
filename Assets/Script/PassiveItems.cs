using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItems : MonoBehaviour
{
    [SerializeField] List<Item> items;

    Character character;

    //[SerializeField] Item armorTest;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Start()
    {
        //Equip(armorTest);
    }

    public void Equip(Item itemToEquip)
    {
        if (items == null)
        {
            items = new List<Item>();
        }

        Item newItemInstance = new Item();
        newItemInstance.Init(itemToEquip.Name);
        newItemInstance.stats.Sum(itemToEquip.stats);

        items.Add(newItemInstance);
        newItemInstance.Equip(character);
    }

    public void UnEquip(Item itemToUnequip)
    {

    }

    internal void UpgradeItem(UpGradeData upGradeData)
    {
        Item itemToUpgrade = items.Find(id => id.Name == upGradeData.item.Name);
        itemToUpgrade.UnEquip(character);
        itemToUpgrade.stats.Sum(upGradeData.ItemStats);
        itemToUpgrade.Equip(character);
    }
}
