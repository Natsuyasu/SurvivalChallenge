using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class ItemStats
{
    public int armor;

    internal void Sum(ItemStats stats)
    {
        armor += stats.armor;
    }
}

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public ItemStats stats;
    public List<UpGradeData> upGrades;

    public void Init(String Name)
    {
        this.Name = Name;
        stats = new ItemStats();
        upGrades = new List<UpGradeData>();
    }

    public void Equip(Character character)
    {
        character.armor += stats.armor; 
    }

    public void UnEquip(Character character)
    {
        character.armor -= stats.armor;
    }

}
