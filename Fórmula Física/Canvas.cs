using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour
{
    [Header("Configuración boton pausa")]
    public Image ImagenPausa;
    public GameObject CanvasPausa;

    public Image textoPausa;
    public Button Config;
    public Button BotonReaundar;
    public Button BotonSalir;
    public GameObject configuracion;

    public void Configuracion()
    {
        configuracion.SetActive(true);

    }
    public void Volver()
    {
        configuracion.SetActive(false);
    }

 
    void Start()
    {
       
        textoPausa.enabled = false;
        ImagenPausa.enabled = false;

        Config.gameObject.SetActive(false);
        BotonReaundar.gameObject.SetActive(false);
        BotonSalir.gameObject.SetActive(false);

        BotonReaundar.onClick.AddListener(Reanudar);
        BotonSalir.onClick.AddListener(Salida);  
    }

    
    void Update()
    {
        //Pausa juego
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausa();
        }

       
    }

    public void Pausa() //Detiene el juego y no podrás continuar hasta que no le des al botón "Reanudar"
    {
        Time.timeScale = 0f;
        ImagenPausa.enabled = true;
        textoPausa.enabled = true;
       
        BotonReaundar.gameObject.SetActive(true);
        BotonSalir.gameObject.SetActive(true);
        Config.gameObject.SetActive(true);
    }

    public void Reanudar()  //Reanuda el juego una vez pausado
    {
        Time.timeScale = 1f;
        ImagenPausa.enabled = false;

        Config.gameObject.SetActive(false);
        BotonReaundar.gameObject.SetActive(false);
        BotonSalir.gameObject.SetActive(false);
    }

    public void Salida()  //Se usa para volver al menu principal
    {
        Application.Quit();
        
    }
}
