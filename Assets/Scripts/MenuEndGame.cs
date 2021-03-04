using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEndGame : MonoBehaviour
{


public GameObject audioInicial;

    
    public void JogarNovamente()
    {
        SceneManager.LoadScene("MenuInicial");
        audioInicial = GameObject.FindGameObjectWithTag("audioInicial");
        Destroy(audioInicial);

    }

    public void segundoano()
    {
        SceneManager.LoadScene("2º ano");
    }

    public void terceiroano()
    {
        SceneManager.LoadScene("3º ano");
    }

    public void Sair()
    {
        Application.Quit();
    }


}

