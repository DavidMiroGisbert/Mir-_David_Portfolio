using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerMedium : MonoBehaviour
{
    public GameObject[] Cards = new GameObject[10]; //Array para mostrar la cara de las cartas
    public GameObject[] CardsDestroy = new GameObject[10]; //Array para mostrar el reverso de las cartas
    int pos;
    int pos2 = 0;
    public int random; //Valor random que determinará la posicón de la carta corazón
    public GameObject player;
    public bool maquina = false; //Boleana para saber si le toca el turno a la máquina
    int check;
    bool Check;
    public Text texto;
    public Text Turno;
    public int ElementosArray;
    public GameObject BotonReinicio;


    void Start() /*En la función Start, se determina la posición (mediante un número random) de la carta corazón, y posteriormente, se coloca la carta corazón en la posición random y el resto de cartas del array son las cartas calavera, llamando
        a determinadas funciones del script Card */
    {
        texto.enabled=false;
        Turno.enabled = false;

        pos2 = ElementosArray / 2; //Dividimos el total de elementos del array entre 2, que en este caso son 10 elementos, por lo tanto es 9 / 2 = 4.5 (4 redondeando).

        player = GameObject.FindWithTag("Card");

        random = Random.Range(0, 10);
        for (pos = 0; pos < Cards.Length; pos++)
        {
            if (pos == random)
            {
                Cards[pos].GetComponent<Card2>().corazon();
            }
            else
            {
                Cards[pos].GetComponent<Card2>().calavera();
            }
        }
    }

    void Update() //Si le toca el turno a la máquina, se llamará a la función Coroutine para que inicie su jugada
    {


        if (maquina == true)
        {
            StartCoroutine("Wait");

            maquina = false;
        }
    }



    IEnumerator Wait()
    {
        Turno.text = "TURN: ANUBIS";
        yield return new WaitForSeconds(1.5f);


        if (pos2 != random) //Si la la posicón del array no coincide con el número random, levantará la carta que le toque y le pasará el turno al jugador
        {
            if (pos2 < random) //Si pos2 es menor que random, entonces la máquina irá hacia la derecha 
            {

                for (int x = 0; x < CardsDestroy.Length; x++) //Este bucle chequea si una carta ha sido levantada por el jugador. En caso positivo, pasa a la siguiente
                {
                    check = CardsDestroy[pos2].GetComponent<CardDestroy2>().ch;
                    Check = CardsDestroy[pos2].GetComponent<CardDestroy2>().Check;

                    if (pos2 == check && Check == true)
                    {
                        pos2 = pos2 + 1;
                    }

                }

                if (pos2 == random) //Si la posicón del array coincide con el número random, se bloqueará el minijuego y saldrá la pantalla de Game Over
                {
                    CardsDestroy[pos2].GetComponent<CardDestroy2>().destroy();
                    texto.text = "GAME OVER";
                    Turno.text = " ";
                    BotonReinicio.SetActive(true);
                }
                else
                {
                    CardsDestroy[pos2].GetComponent<CardDestroy2>().destroy(); //Llama a la función destroy del Script CardDestroy para desactivar la carta
                    pos2 = pos2 + 1;
                    Turno.text = "TURN: PLAYER";
                }
            }

            if (pos2 > random) //Si pos2 es mayor que random, entonces la máquina irá hacia la izquierda
            {

                for (int x = 0; x < CardsDestroy.Length; x++) //Este bucle chequea si una carta ha sido levantada por el jugador. En caso positivo, pasa a la siguiente
                {
                    check = CardsDestroy[pos2].GetComponent<CardDestroy2>().ch;
                    Check = CardsDestroy[pos2].GetComponent<CardDestroy2>().Check;

                    if (pos2 == check && Check == true)
                    {
                        pos2 = pos2 - 1;
                    }

                }

                if (pos2 == random) //Si la posicón del array coincide con el número random, se bloqueará el minijuego y saldrá la pantalla de Game Over
                {
                    CardsDestroy[pos2].GetComponent<CardDestroy2>().destroy();
                    texto.text = "GAME OVER";
                    Turno.text = " ";
                    BotonReinicio.SetActive(true);
                }
                else
                {
                    CardsDestroy[pos2].GetComponent<CardDestroy2>().destroy(); //Llama a la función destroy del Script CardDestroy para desactivar la carta
                    pos2 = pos2 - 1;

                    Turno.text = "TURN: PLAYER";
                }
            }


        }
        else
        {
            CardsDestroy[pos2].GetComponent<CardDestroy2>().destroy();
            texto.text = "GAME OVER";
            Turno.text = " ";
            BotonReinicio.SetActive(true);
        }




    }
}