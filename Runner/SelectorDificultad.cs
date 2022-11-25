using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorDificultad : MonoBehaviour
{
    public GameObject Plano;
    public GameObject Contador;
    public Text Tiempo;
    public Text Vidas;
    public Text Seleccione;
    public Image Fondo;
    public GameObject BotonF;
    public GameObject BotonN;
    public GameObject BotonD;
    // Start is called before the first frame update
    void Start() //Activación menú inicial
    {
        Fondo.enabled = true;
        Tiempo.enabled = false;
        Vidas.enabled = false;
        Seleccione.enabled = true;
        BotonF.SetActive(true);
        BotonN.SetActive(true);
        BotonD.SetActive(true);
}
    public void Facil()
    {
        //Presets facil
        TerrainGenerator Facil = Plano.GetComponent<TerrainGenerator>();
        Vidas contador = Contador.GetComponent<Vidas>();
        Facil.facil = true;
        Tiempo.enabled = true;
        Vidas.enabled = true;
        //Desactivación menú inicial
        Fondo.enabled = false;
        Seleccione.enabled = false;
        BotonF.SetActive(false);
        BotonN.SetActive(false);
        BotonD.SetActive(false);
        //Inicio del tiempo de partida
        contador.segundos = 0f;
    }
    public void Normal()
    {
        //Presets normal
        TerrainGenerator Normal = Plano.GetComponent<TerrainGenerator>();
        Vidas contador = Contador.GetComponent<Vidas>();
        Normal.normal = true;
        Tiempo.enabled = true;
        Vidas.enabled = true;
        //Desactivación menú inicial
        Fondo.enabled = false;
        Seleccione.enabled = false;
        BotonF.SetActive(false);
        BotonN.SetActive(false);
        BotonD.SetActive(false);
        //Inicio del tiempo de partida
        contador.segundos = 0f;
    }
    public void Dificil()
    {
        //Presets difícil
        TerrainGenerator Dificil = Plano.GetComponent<TerrainGenerator>();
        Vidas contador = Contador.GetComponent<Vidas>();
        Dificil.dificil = true;
        Tiempo.enabled = true;
        Vidas.enabled = true;
        //Desactivación menú inicial
        Fondo.enabled = false;
        Seleccione.enabled = false;
        BotonF.SetActive(false);
        BotonN.SetActive(false);
        BotonD.SetActive(false);
        //Inicio del tiempo de partida
        contador.segundos = 0f;
    }
}
