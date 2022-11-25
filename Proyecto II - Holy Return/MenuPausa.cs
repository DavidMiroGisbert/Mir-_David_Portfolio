using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuPausa : MonoBehaviour
{
    public GameObject CanvasPausa;
    bool PausaJuego;
    
    // Start is called before the first frame update
    void Start()
    {
        PausaJuego = false;
        Time.timeScale = 1;
        CanvasPausa.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PausaJuego == false && CharacterController.ModoCombate == false)
        {
            PausaJuego = true;
            CanvasPausa.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && PausaJuego == true)
        {
            PausaJuego = false;
            CanvasPausa.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MenuInicio");
    }

    public void Continuar()
    {
        PausaJuego = false;
        CanvasPausa.SetActive(false);
        Time.timeScale = 1;
    }
}
