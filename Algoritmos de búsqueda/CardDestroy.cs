using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CardDestroy : MonoBehaviour
{
    public GameObject maquina;
    public GameObject VidasExtra;
    public bool player = true; //Boolena para saber si le toca el turno al jugador
    public int Value; //Valor que tiene cada carta (de 0 a 9) para saber en qué posicón se encuentra dicha carta
    public GameObject random;
    int ran;
    public int ch;
    public bool Check = false; //Booleana para comprobar que una carta ha sido levantada
    public Text texto;
    public Text turno;
    void Update()
    {



        ch = Value;
    }

    private void OnMouseDown() //Función para que el jugador pueda clicar sobre una carta y "voltearla"
    {
        if (player == true)
        {

            ran = random.GetComponent<GameManagerEasy>().random; //Variable que recoge el valor de la varaible random del Script GameManager para saber la posición de la carta corazón



            if (Value == ran) //Si Value es igual a random, entonces el minijuego se bloquea y sale un mensaje de +1UP, para que el jugador reciba una vida.
            {

                gameObject.SetActive(false);
                player = false;
                maquina.GetComponent<GameManagerEasy>().maquina = false;
                turno.text = " ";
                texto.text = "Victoria";
                VidasExtra.GetComponent<Vidas>().Victoria();

            }
            else //Si Value no es igual a random, entonces le pasa el turno a la máquina, y además, le pasa la booleana Check como true para que la máquina sepa que esa carta está levantada.
            {
                gameObject.SetActive(false);
                maquina.GetComponent<GameManagerEasy>().maquina = true;
                Check = true;
                player = false;
            }
        }
    }
    
    public void destroy() //Función que sirve para desactivar la carta la carta
    {
        gameObject.SetActive(false);
    }


}