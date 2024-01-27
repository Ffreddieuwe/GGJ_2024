using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;

    private void Start()
    {
        MainMenuButton();
    }

    public void PlayNowButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("level");
    }

    public void CreditsButton()
    {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
