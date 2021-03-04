using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Equações : MonoBehaviour
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

    string equação, equaçãoAntiga;

    public List<int> divisores = new List<int>();

    void Start()
    {
        equaçãoAdição();
        score = 0;
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
            if(score<5){
            equaçãoAntiga = equação;
            equaçãoAdição();
            contdownTime = 15;
            }
            else if(score<10){
            equaçãoAntiga = equação;
            equaçãoSubtração();
                contdownTime = 15;
            }
            else if(score<15){
            equaçãoAntiga = equação;
            equaçãoMultiplicação();
                contdownTime = 20;
            }
            else if(score<20){
            equaçãoAntiga = equação;
            equaçãoDivisão();
                contdownTime = 20;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)){
            if(respostaCorreta == int.Parse(Resposta.text)){
                Score.text = (++score).ToString();
                Resposta.text = "";
                contdownTime = 15;
                if(score<5){
                equaçãoAntiga = equação;
                equaçãoAdição();
                contdownTime = 15;
                }
                else if(score<10){
                equaçãoAntiga = equação;
                equaçãoSubtração();
                    contdownTime = 15;
                }
                else if(score<15){
                equaçãoAntiga = equação;
                equaçãoMultiplicação();
                    contdownTime = 20;
                }
                else if(score<20){
                equaçãoAntiga = equação;
                equaçãoDivisão();
                    contdownTime = 20;
                }

            }else{
                Resposta.text = "";
                acertouTudo = false;
                if(score>0){
                    Score.text = (--score).ToString(); 
                }

                if(score<5){
                equaçãoAntiga = equação;    
                equaçãoAdição();
                contdownTime = 15;
                }

                else if(score<10){
                equaçãoAntiga = equação;   
                equaçãoSubtração();
                contdownTime = 15;
                }

                else if(score<15){
                equaçãoAntiga = equação;   
                equaçãoMultiplicação();
                contdownTime = 15;
                }

                else if(score<20){
                equaçãoAntiga = equação;
                equaçãoDivisão();
                contdownTime = 15;
                }
            }   
        }


        if(score>=20){
            
            textoTempo.SetActive(false);
            contdownDisplay.text = "";
            if (acertouTudo==true){
                acertouTodasUI.SetActive(true);
            }else{
                completeLevelUI.SetActive(true);
            }
        }
    }    
    

    void equaçãoAdição(){
        aux1 = Random.Range(0,10);
        aux2 = Random.Range(0,10);

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
        aux1 = Random.Range(0,10);
        operação.text = "-";
        aux2 = Random.Range(0,10);

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

    void equaçãoMultiplicação(){
        aux1 = Random.Range(0,10);
        aux2 = Random.Range(0,10);

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

    void equaçãoDivisão(){

        //limpa a lista de divisores a cada chamada do método.
        divisores.Clear();

        aux1 = Random.Range(1,10);
       
        // teste para achar somente os divisores do primeiro número e guarda-lo em uma lista de inteiros, evitando números com vírgula.
        for (int i =1; i<= aux1; i++){
            if (aux1 %i==0){
                 divisores.Add(i);
            }
        }

        Debug.Log(score + " " + divisores.Count);
        for (int i =0; i<divisores.Count; i++){
            Debug.Log(score + " " + divisores[i]);
        }

        
        //index recebe valor aleatório para determinar posição na lista de divisores.
        index = Random.Range(0,(divisores.Count-1));

        //segundo número recebe o divisor da lista na posição do index.
        aux2 = divisores[index];

        equação = (aux1.ToString() + operação + aux2.ToString());

        if(equação.Equals(equaçãoAntiga)){
            equaçãoDivisão();
        }else{
            primeiroNumero.text = aux1.ToString();
            operação.text = "/";
            segundoNumero.text = aux2.ToString();
        }

        respostaCorreta = int.Parse(primeiroNumero.text) / int.Parse(segundoNumero.text);
    }



}
