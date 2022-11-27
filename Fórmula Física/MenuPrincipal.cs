using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Dificultades;
    public GameObject Control;
   
    void Start()
    {
        MainMenu.SetActive(true);
        Dificultades.SetActive(false);
    }

    public void Jugar() //Método para activar las dificultades
    {
        MainMenu.SetActive(false);
        Dificultades.SetActive(true);
    }

    public void Salir()  //Método para salir del juego
    {
        Application.Quit();
        
    }
    public void Controles() //Método para acceder a controles
    {
        MainMenu.SetActive(false);
        Dificultades.SetActive(false);
        Control.SetActive(true);
    }

    public void Volver() //Método para volver  al juego
    {
        MainMenu.SetActive(true);
        Dificultades.SetActive(false);
        Control.SetActive(false);
    }

   
}
