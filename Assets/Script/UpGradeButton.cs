using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpGradeButton : MonoBehaviour
{
    [SerializeField] Image icon;

    public void Set(UpGradeData upGradeData)
    {
        icon.sprite = upGradeData.icon;
    }

    internal void Clean()
    {
        icon.sprite = null;
    }

}
