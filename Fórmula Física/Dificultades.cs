using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dificultades : MonoBehaviour
{
    //variables para poder comprobar el nivel de dificultad elegido
    public static bool facil;
    public static bool normal;
    public static bool dificil;
    public static bool experto;

    public void Facil ()  //Modo facil del juego
    {
        facil = true;
        normal = false;
        dificil = false;
        experto = false;
        SceneManager.LoadScene("Canon 2");
    }


    public void Normal()  //Modo Normal del juego
    {
        facil = false;
        normal = true;
        dificil = false;
        experto = false;
        SceneManager.LoadScene("Canon 2");
    }


    public void Dificil()  //Modo difícil del juego
    {
        facil = false;
        normal = false;
        dificil = true;
        experto = false;
        SceneManager.LoadScene("Canon 2");
    }


    public void Experto() //Modo experto del juego
    {
        facil = false;
        normal = false;
        dificil = false;
        experto = true;
        SceneManager.LoadScene("Canon 2");
    }
}
