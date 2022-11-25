using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Camera Principal;
    public Camera Camara1;
    public Camera Camara2;
    public Camera Camara3;

    public GameObject Dificultad;
    public GameObject BotonMinijuego;
    public GameObject BotonReinicio;
    public Text VidasText;
    public Text GameOver;
    public Text Tiempo;
    public Text Turno;
    public Text ResultadoMinijuego;
    public Image Imagen;
    public Text Resultado;
    public float vidas=5f;
    public float segundos = 0f;
    public bool[] dificultadAlgoritmo;
    // Start is called before the first frame update
    void Start()
    {
        Principal.enabled = true;
        Camara1.enabled = false; 
        Camara2.enabled = false;
        Camara3.enabled = false;
        BotonMinijuego.SetActive(false);
        BotonReinicio.SetActive(false);
        ResultadoMinijuego.enabled = false;
        Turno.enabled = false;
        VidasText.text = "Vidas: " + vidas;
        Tiempo.text = "Tiempo: " + segundos;
        GameOver.enabled = false;
        Resultado.enabled = false;
        if (segundos == 0)
        {
            StartCoroutine("Contador");
        }
    }
    
    private void OnCollisionEnter(Collision collision) //Función que gestiona de las vidas así como de las colisiones
    {
        if (collision.gameObject.tag == "RestarVid")
        {
            vidas = vidas - 1f;
            VidasText.text = "Vidas: " + vidas;
            Destroy(collision.gameObject);
        }
        if (vidas <= 0)
        {
            if (dificultadAlgoritmo[0]==false || dificultadAlgoritmo[1] == false || dificultadAlgoritmo[2] == false)
            {
                Fin1Partida();
            }
            if (dificultadAlgoritmo[0] == true || dificultadAlgoritmo[1] == true || dificultadAlgoritmo[2] == true)
            {
                Fin2Partida(); 
            }


        }
        if(collision.gameObject.tag == "Final")
        {
                if (dificultadAlgoritmo[0] == false || dificultadAlgoritmo[1] == false || dificultadAlgoritmo[2] == false)
                {
                    Fin1Partida();
                }
                if (dificultadAlgoritmo[0] == true || dificultadAlgoritmo[1] == true || dificultadAlgoritmo[2] == true)
                {
                    Fin2Partida();
                }
            }
          
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "SumarVid")
        {
            vidas = vidas + 0.5f;
            VidasText.text = "Vidas: " + vidas;
            Destroy(collision.gameObject);
        }
    }
    void Fin1Partida() //Función para cuando el jugador ha muerto la primera vez
    {
        VidasText.GetComponent<Text>().text = (" ");
        GameOver.enabled = true;
        Resultado.enabled = true;
        Imagen.enabled = true;
        Tiempo.enabled = false;
        VidasText.enabled = false;
        Imagen.GetComponent<Image>();
        Resultado.GetComponent<Text>().text = ("Has aguantado " + segundos + " segundos");
        GameOver.GetComponent<Text>().text = ("GAME OVER");
        StopCoroutine("Contador");
        BotonMinijuego.SetActive(true);
    }
    void Fin2Partida()//Función para cuando el jugador ha ganado el minijuego, ha vuelto a la vida y ha muerto otra vez
    {
        VidasText.GetComponent<Text>().text = (" ");
        GameOver.enabled = true;
        Resultado.enabled = true;
        Imagen.enabled = true;
        Tiempo.enabled = false;
        VidasText.enabled = false;
        Imagen.GetComponent<Image>();
        Resultado.GetComponent<Text>().text = ("Has aguantado " + segundos + " segundos");
        GameOver.GetComponent<Text>().text = ("GAME OVER");
        StopCoroutine("Contador");
        BotonReinicio.SetActive(true);
    }
    private IEnumerator Contador()
    {
        yield return new WaitForSeconds(1f);
        segundos++;
       
        Tiempo.text = "Tiempo: " + segundos;
        StartCoroutine("Contador");
        
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    public void Minijuego()
    {
        //Minijuego para volver a conseguir otra vida y continuar la partida, aquí se desactiva el Perlin y se activa el minijuego según la dificultad elegida(Carpeta Algoritmo de Busqueda)
        TerrainGenerator dificultad = Dificultad.GetComponent<TerrainGenerator>();
        if (dificultad.facil==true)
        {
            dificultad.facil = false;
            Camara1.enabled = true;
            Principal.enabled = false;
            BotonMinijuego.SetActive(false);
            GameOver.enabled = false;
            Resultado.enabled = false;
            Imagen.enabled = false;
            StopCoroutine("Contador");
            dificultadAlgoritmo[0] = true;
            ResultadoMinijuego.enabled = true;
            Turno.enabled = true;
        }
        if (dificultad.normal==true)
        {
            dificultad.normal = false;
            Camara2.enabled = true;
            Principal.enabled = false;
            BotonMinijuego.SetActive(false);
            GameOver.enabled = false;
            Resultado.enabled = false;
            Imagen.enabled = false;
            StopCoroutine("Contador");
            dificultadAlgoritmo[1] = true;
            ResultadoMinijuego.enabled = true;
            Turno.enabled = true;
        }
        if (dificultad.dificil==true)
        {
            dificultad.dificil = false;
            Camara3.enabled = true;
            Principal.enabled = false;
            BotonMinijuego.SetActive(false);
            GameOver.enabled = false;
            Resultado.enabled = false;
            Imagen.enabled = false;
            StopCoroutine("Contador");
            dificultadAlgoritmo[2] = true;
            ResultadoMinijuego.enabled = true;
            Turno.enabled = true;
        }
        
        
    }
    public void Victoria()
    {
        StartCoroutine("Continuar");
    }
    public IEnumerator Continuar()
    {

        yield return new WaitForSeconds(2f);
        TerrainGenerator dificultad = Dificultad.GetComponent<TerrainGenerator>();
        Camara1.enabled = false;
        Camara2.enabled = false;
        Camara3.enabled = false;
        Principal.enabled = true;
        BotonMinijuego.SetActive(false);
        GameOver.enabled = false;
        Resultado.enabled = false;
        Imagen.enabled = false;
        Tiempo.enabled = true;
        VidasText.enabled = true;
        ResultadoMinijuego.enabled = false;
        Turno.enabled = false;
        StartCoroutine("Contador");
        vidas = 5f;
        if (dificultadAlgoritmo[0] == true)
        {
            dificultad.facil = true;
        }
        if (dificultadAlgoritmo[1] == true)
        {
            dificultad.normal = true;
        }
        if (dificultadAlgoritmo[2] == true)
        {
            dificultad.dificil = true;
        }
    }
    public void Restart() //Funcion para volver a cargar el juego
    {
        SceneManager.LoadScene("Runner");
    }
}
