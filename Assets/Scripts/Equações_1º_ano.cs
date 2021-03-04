using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Equações_1º_ano : MonoBehaviour
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
    public bool acertouTudo;
    int aux1, aux2, index;
    
    int acertos1, acertos2, erros1, erros2, erros2Tempo, erros1Tempo;
    public Text acertos1_txt, acertos2_txt, erros1_txt, erros2_txt, erros2Tempo_txt, erros1Tempo_txt;
    public GameObject menuResultados;

    string equação, equaçãoAntiga;

    public List<int> divisores = new List<int>();

    void Start()
    {
        equaçãoAdição();
        score = 0;
        Score.text = score.ToString();
        acertouTudo = true;
        acertos1 = 0;
        acertos2 = 0;
        erros1 = 0;
        erros2 = 0;
        erros1Tempo = 0;
        erros2Tempo = 0;
       
    }

    void Update()
    {
        contdownTime -= Time.deltaTime;
        contdownDisplay.text = contdownTime.ToString("f0");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            score = 29;
        }

        if(contdownTime <= 0)
        {
            acertouTudo = false;
            if(score>0){
               Score.text = (--score).ToString(); 
            }
            if(score<15){
                equaçãoAntiga = equação;
                equaçãoAdição();
                erros1Tempo++;
            }
            else if(score<30){
                equaçãoAntiga = equação;
                equaçãoSubtração();
                erros2Tempo++;
            }

        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)){
            if(respostaCorreta == int.Parse(Resposta.text)){
                Score.text = (++score).ToString();
                Resposta.text = "";
                if(score<15){
                    equaçãoAntiga = equação;
                    equaçãoAdição();
                    acertos1++;
                }
                else if(score<30){
                    equaçãoAntiga = equação;
                    equaçãoSubtração();
                    acertos2++;
                }else{
                    
                    textoTempo.SetActive(false);
                    contdownDisplay.text = "";

                    if (acertouTudo==true){
                        acertouTodasUI.SetActive(true);
                    }else{
                        
                        acertos1_txt.text = "Acertos Adição: " + (acertos1).ToString();
                        acertos2_txt.text = "Acertos Subtração: " + (acertos2).ToString();
                        erros1_txt.text = "Erros Adição: " + (erros1).ToString();
                        erros2_txt.text = "Erros Subtração: " + (erros2).ToString();
                        erros1Tempo_txt.text = "Adição: " + (erros1Tempo).ToString();
                        erros2Tempo_txt.text = "Subtração : " + (erros2Tempo).ToString();
                        completeLevelUI.SetActive(true);


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
                    equaçãoAdição();
                    erros1++;
                }
                else if(score<30){
                    equaçãoAntiga = equação;
                    equaçãoSubtração();
                    if (score >= 15) { erros2++; }
                }
            }   
        }

    }    
    

    void equaçãoAdição(){

        if (score<5){
            aux1 = Random.Range(0,10);
            aux2 = Random.Range(0,10);
            contdownTime = 15;   
        }
        else if (score<10){
            aux1 = Random.Range(10,20);
            aux2 = Random.Range(10,20); 
            contdownTime = 25;  
        }
        else if (score<15){
            aux1 = Random.Range(15,30);
            aux2 = Random.Range(15,30);
            contdownTime = 40;    
        }
       


        operação.text = "+";

        equação = (aux1.ToString() + operação + aux2.ToString());
        if(equação.Equals(equaçãoAntiga)){
            equaçãoAdição();
        }else{
            primeiroNumero.text = aux1.ToString();
            operação.text = "+";
            segundoNumero.text = aux2.ToString();
        }
        respostaCorreta = int.Parse(primeiroNumero.text) + int.Parse(segundoNumero.text);

        
    }

    void equaçãoSubtração(){

        if (score<20){
            aux1 = Random.Range(0,10);
            aux2 = Random.Range(0,10);
            contdownTime = 15;   
        }
        else if (score<25){
            aux1 = Random.Range(5,20);
            aux2 = Random.Range(5,20); 
            contdownTime = 25; 
        }
        else if (score<30){
            aux1 = Random.Range(10,30);
            aux2 = Random.Range(10,30); 
            contdownTime = 40;  
        }
        
        operação.text = "-";

        if(aux1>=aux2){
            primeiroNumero.text = aux1.ToString();
            segundoNumero.text = aux2.ToString();
        }else{
            primeiroNumero.text = aux2.ToString();
            segundoNumero.text = aux1.ToString();
        }
        equação = (int.Parse(primeiroNumero.text).ToString() + operação + int.Parse(segundoNumero.text).ToString());

        if(equação.Equals(equaçãoAntiga)){
            equaçãoSubtração();
        }else{
            respostaCorreta = int.Parse(primeiroNumero.text) - int.Parse(segundoNumero.text);
        }


        
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
