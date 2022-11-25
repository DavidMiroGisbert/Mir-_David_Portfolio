using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerHard : MonoBehaviour
{
    public GameObject[] Cards = new GameObject[10]; //Array para mostrar la cara de las cartas
    public GameObject[] CardsDestroy = new GameObject[10]; //Array para mostrar el reverso de las cartas
    public GameObject BotonReinicio;
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
    int MInf;
    int MSup;



    void Start() /*En la función Start, se determina la posición (mediante un número random) de la carta corazón, y posteriormente, se coloca la carta corazón en la posición random y el resto de cartas del array son las cartas calavera, llamando
        a determinadas funciones del script Card */
    {
        //Marcamos los marcadores inferior y superior
        texto.enabled=false;
        Turno.enabled = false;

        MInf = ElementosArray / 3;
        MSup = ElementosArray * 2 / 3 + 1;

        player = GameObject.FindWithTag("Card");

        random = Random.Range(0, 10);
        for (pos = 0; pos < Cards.Length; pos++)
        {
            if (pos == random)
            {
                Cards[pos].GetComponent<Card3>().corazon();
            }
            else
            {
                Cards[pos].GetComponent<Card3>().calavera();
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
            if (random <= MInf) //Si random es menor que el marcador inferior, entonces pos2 será igual al marcador inferior e irá hacia la izquierda 
            {
                pos2 = MInf;
                for (int x = 0; x < CardsDestroy.Length; x++) //Este bucle chequea si una carta ha sido levantada por el jugador. En caso positivo, pasa a la siguiente
                {
                    check = CardsDestroy[pos2].GetComponent<CardDestroy3>().ch;
                    Check = CardsDestroy[pos2].GetComponent<CardDestroy3>().Check;

                    if (pos2 == check && Check == true)
                    {
                        MInf = MInf - 1;
                    }

                }

                if (pos2 == random) //Si la posicón del array coincide con el número random, se bloqueará el minijuego y saldrá la pantalla de Game Over
                {
                    CardsDestroy[pos2].GetComponent<CardDestroy3>().destroy();
                    texto.text = "GAME OVER";
                    Turno.text = " ";
                    BotonReinicio.SetActive(true);
                }
                else
                {
                    CardsDestroy[pos2].GetComponent<CardDestroy3>().destroy(); //Llama a la función destroy del Script CardDestroy para desactivar la carta
                    MInf = MInf - 1;

                    Turno.text = "TURN: PLAYER";
                }
            }

            if (random >= MInf && random <= MSup) //Si random es mayor que el marcador inferior pero menor que el superior, entonces pos2 será igual al marcador inferior e irá hacia la derecha 
            {
                pos2 = MInf;

                for (int x = 0; x < CardsDestroy.Length; x++) //Este bucle chequea si una carta ha sido levantada por el jugador. En caso positivo, pasa a la siguiente
                {
                    check = CardsDestroy[pos2].GetComponent<CardDestroy3>().ch;
                    Check = CardsDestroy[pos2].GetComponent<CardDestroy3>().Check;

                    if (pos2 == check && Check == true)
                    {
                        MInf = MInf + 1;
                    }

                }

                if (pos2 == random) //Si la posicón del array coincide con el número random, se bloqueará el minijuego y saldrá la pantalla de Game Over
                {
                    CardsDestroy[pos2].GetComponent<CardDestroy3>().destroy();
                    texto.text = "GAME OVER";
                    Turno.text = " ";
                    BotonReinicio.SetActive(true);
                }
                else
                {
                    CardsDestroy[pos2].GetComponent<CardDestroy3>().destroy(); //Llama a la función destroy del Script CardDestroy para desactivar la carta
                    MInf = MInf + 1;

                    Turno.text = "TURN: PLAYER";
                }
            }

            if (random >= MSup) //Si random es mayor que el marcador superior, entonces pos2 será igual al marcador superior e irá hacia la derecha 
            {
                pos2 = MSup;

                for (int x = 0; x < CardsDestroy.Length; x++) //Este bucle chequea si una carta ha sido levantada por el jugador. En caso positivo, pasa a la siguiente
                {
                    check = CardsDestroy[pos2].GetComponent<CardDestroy3>().ch;
                    Check = CardsDestroy[pos2].GetComponent<CardDestroy3>().Check;

                    if (pos2 == check && Check == true)
                    {
                        MSup = MSup + 1;
                    }

                }

                if (pos2 == random) //Si la posicón del array coincide con el número random, se bloqueará el minijuego y saldrá la pantalla de Game Over
                {
                    CardsDestroy[pos2].GetComponent<CardDestroy3>().destroy();
                    texto.text = "GAME OVER";
                    BotonReinicio.SetActive(true);
                    Turno.text = " ";
                }
                else
                {
                    CardsDestroy[pos2].GetComponent<CardDestroy3>().destroy(); //Llama a la función destroy del Script CardDestroy para desactivar la carta
                    MSup = MSup + 1;

                    Turno.text = "TURN: PLAYER";
                }
            }


        }
        else
        {
            CardsDestroy[pos2].GetComponent<CardDestroy3>().destroy();
            texto.text = "GAME OVER";
            Turno.text = " ";
            BotonReinicio.SetActive(true);

        }
    }
}