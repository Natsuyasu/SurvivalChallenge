using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpGradePanelManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    PauseManager pauseManager;

    [SerializeField] List<UpGradeButton> upGradeButtons;

    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    private void Start()
    {
        HideButtons();
    }

    public void OpenPanel(List<UpGradeData> upGradeDatas)
    {
        Clean();
        pauseManager.PauseGame();
        panel.SetActive(true);

        
        for (int i = 0; i < upGradeDatas.Count; i++)
        {
            upGradeButtons[i].gameObject.SetActive(true);
            upGradeButtons[i].Set(upGradeDatas[i]);
        }
    }

    public void Clean()
    {
        for(int i = 0; i < upGradeButtons.Count; i++)
        {
            upGradeButtons[i].Clean();
        }
    }

    public void Upgrade(int pressButtonID)
    {
        //Debug.Log("Player pressed:" + pressButtonID.ToString());
        GameManager.instance.playerTransform.GetComponent<Level>().Upgrade(pressButtonID);
        ClosePanel();
    }

    public void ClosePanel()
    {
        HideButtons();

        pauseManager.UnPauseGame();
        panel.SetActive(false);
    }

    private void HideButtons()
    {
        for (int i = 0; i < upGradeButtons.Count; i++)
        {
            upGradeButtons[i].gameObject.SetActive(false);
        }
    }
}
