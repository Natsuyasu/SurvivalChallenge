using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpGradeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image icon;
    [SerializeField] Text text;
    private string UpgradeName;

    public void Set(UpGradeData upGradeData)
    {
        icon.sprite = upGradeData.icon;
        UpgradeName = upGradeData.Name;
    }

    internal void Clean()
    {
        icon.sprite = null;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        // 鼠标悬停在按钮上时，在文本框中显示对象名称
        text.text = UpgradeName;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 鼠标移出按钮时，清空文本框
        text.text = "";
    }
}
