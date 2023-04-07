using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWinManager : MonoBehaviour
{
    [SerializeField] GameObject winMessagePanel;
    PauseManager PauseManager;
    [SerializeField] DataCotainer dataCotainer;
    //private List<Scene> activeScenes = new List<Scene>();

    private void Start()
    {
        /*int sceneCount = SceneManager.sceneCount;
        for (int i = 0; i < sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.isLoaded && scene.IsValid() && scene.buildIndex != -1)
            {
                activeScenes.Add(scene);
            }
        }
        Scene sceneToFind = activeScenes[1];
        string sceneToFindName = sceneToFind.name;
        SceneManager.LoadScene(sceneToFindName, LoadSceneMode.Additive);
        GameObject targetPanel = GameObject.Find("YouWin Panel");
        winMessagePanel = targetPanel;
        SceneManager.LoadScene("Essencial", LoadSceneMode.Single);*/
        PauseManager = GetComponent<PauseManager>();
        
    }
    public void Win()
    {
        winMessagePanel.SetActive(true);
        PauseManager.PauseGame();
        dataCotainer.stageComplete(0);
    }
}
