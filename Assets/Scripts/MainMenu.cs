using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject HelpMenu;
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameHelp()
    {
        HelpMenu.SetActive(true);
    }
    public void CloseHelp()
    {
        HelpMenu.SetActive(false);


    }

    public void PrimeiroAno()
    {
        SceneManager.LoadScene("1º ano");
    }

    public void SegundoAno()
    {
        SceneManager.LoadScene("2º ano");
    }
    public void TerceiroAno()
    {
        SceneManager.LoadScene("3º ano");
    }
}
