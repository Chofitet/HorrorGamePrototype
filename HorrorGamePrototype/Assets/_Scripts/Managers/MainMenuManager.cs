using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject QuitConfirmationMenu;

    private void Start()
    {
        QuitConfirmationMenu.SetActive(false);
    }
    public void QuitGame()
    {
        QuitConfirmationMenu.SetActive(true);
    }

    public void QuitConfirmation()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("AAAAAAAAAAAA");
    }

    public void Back ()
    {
        QuitConfirmationMenu.SetActive(false);
    }
}
