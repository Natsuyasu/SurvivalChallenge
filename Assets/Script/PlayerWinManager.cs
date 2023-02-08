using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinManager : MonoBehaviour
{
    [SerializeField] GameObject winMessagePanel;
    PauseManager PauseManager;
    [SerializeField] DataCotainer dataCotainer;

    private void Start()
    {
        PauseManager = GetComponent<PauseManager>();
    }
    public void Win()
    {
        winMessagePanel.SetActive(true);
        PauseManager.PauseGame();
        dataCotainer.stageComplete(0);
    }
}
