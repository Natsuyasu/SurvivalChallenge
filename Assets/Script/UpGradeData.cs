using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpGradeType
{
    WeaponUpgrade,
    ItemUpGrade,
    WeaponUnlock,
    ItemUnlock

}

[CreateAssetMenu]

public class UpGradeData : ScriptableObject
{
    public UpGradeType upGradeType;
    public string Name;
    public Sprite icon;
}
