using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Equações_2º_ano : MonoBehaviour
{
    
    public Text primeiroNumero;
    public Text operação;
    public Text segundoNumero;
    public Text Score;

    public InputField Resposta;

    public GameObject completeLevelUI;

    public GameObject textoTempo;
    public GameObject acertouTodasUI;
    public float contdownTime;
    public Text contdownDisplay;

    int respostaCorreta;
    int score;
    bool acertouTudo;
    int aux1, aux2, index;

    int acertos1, erros1, erros1Tempo;
    public Text acertos1_txt, erros1_txt, erros1Tempo_txt;
    public GameObject menuResultados;

    string equação, equaçãoAntiga;

    public List<int> divisores = new List<int>();

    void Start()
    {
        equaçãoMultiplicação();
        score = 0;
        Score.text = score.ToString();
        acertouTudo = true;
       
    }

    void Update()
    {
        contdownTime -= Time.deltaTime;
        contdownDisplay.text = contdownTime.ToString("f0");

        if(contdownTime <= 0)
        {
            acertouTudo = false;
            if(score>0){
               Score.text = (--score).ToString(); 
            }
            if(score<15){
            equaçãoAntiga = equação;
            equaçãoMultiplicação();
                erros1Tempo++;
            }

        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if(respostaCorreta == int.Parse(Resposta.text)){
                Score.text = (++score).ToString();
                Resposta.text = "";
                if(score<15){
                    equaçãoAntiga = equação;
                    equaçãoMultiplicação();
                    acertos1++;
                }
                else{
                    textoTempo.SetActive(false);
                    contdownDisplay.text = "";
                    if (acertouTudo==true){
                        acertouTodasUI.SetActive(true);
                    }else{
                    completeLevelUI.SetActive(true);
                        acertos1_txt.text = "Acertos Divisão: " + (acertos1).ToString();
                        erros1_txt.text = "Erros Divisão: " + (erros1).ToString();
                        erros1Tempo_txt.text = "Divisão: " + (erros1Tempo).ToString();
                    }
                }
            }else{
                Resposta.text = "";
                acertouTudo = false;
                if(score>0){
                    Score.text = (--score).ToString(); 
                }

                if(score<15){
                equaçãoAntiga = equação;    
                equaçãoMultiplicação();
                    erros1++;
                }
            }   
        }

    }    
    

    void equaçãoMultiplicação(){

        if (score<5){
            aux1 = Random.Range(0,5);
            aux2 = Random.Range(0,5); 
            contdownTime = 15;  
        }
        else if (score<10){
            aux1 = Random.Range(5,10);
            aux2 = Random.Range(5,10);
            contdownTime = 25;  
        }
        else if (score<15){
            aux1 = Random.Range(10,15);
            aux2 = Random.Range(10,15);
            contdownTime = 40;   
        }


        operação.text = "x";

        equação = (aux1.ToString() + operação + aux2.ToString());

        if(equação.Equals(equaçãoAntiga)){
            equaçãoMultiplicação();
        }else{
            primeiroNumero.text = aux1.ToString();
            operação.text = "x";
            segundoNumero.text = aux2.ToString();
        }

        respostaCorreta = int.Parse(primeiroNumero.text) * int.Parse(segundoNumero.text);
    }

    public void AbreResultados()
    {
        menuResultados.SetActive(true);
    }

    public void FechaResultados()
    {
        menuResultados.SetActive(false);
    }


}
