using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadScene("AAAAAAAAAAAA");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
