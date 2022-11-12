using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    FirstPersonControl FPC;
    bool isPaused;

    private void Start()
    {
        FPC = FindObjectOfType<FirstPersonControl>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                
                PauseMenu.SetActive(true);
                Time.timeScale = 0;
                
                isPaused = true;
                FPC.StopRotation = true;
            }
            else
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
                
                isPaused = false;
                FPC.StopRotation = false;

            }
        }
    }
    public void Continue()
    { 
        // FPC.enabled = true;
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        FPC.StopRotation = false;
        isPaused = false;
    }
   
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
}
