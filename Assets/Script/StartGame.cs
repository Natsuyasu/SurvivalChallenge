using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    /*Scene scene = SceneManager.GetActiveScene();
    string Name = StartGame.scene.name;
    string NextScene;
    void swich()
    {
        case Name == "MainMenu":

            break;

    }*/
    public void StartGamePlayer(string stageToPlay)
    {
        SceneManager.LoadScene("Essencial",LoadSceneMode.Single);
        SceneManager.LoadScene(stageToPlay, LoadSceneMode.Additive);
        
    }
}
