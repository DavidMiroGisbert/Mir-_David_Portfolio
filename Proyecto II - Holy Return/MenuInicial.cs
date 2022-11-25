using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicial : MonoBehaviour
{
    //botones
    public GameObject TextoControles;
    public Button botonContinuar;
    bool ControlesActivos;

    //AUDIO
    AudioSource myAudio;
    public AudioClip interfz;

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        TextoControles.SetActive(false);
        ControlesActivos = false;

        if (PlayerPrefs.GetInt("puntoControl") == 0)
        {
            botonContinuar.gameObject.SetActive(false);
        }

        else
        {
            //Debug.Log("Dentro del ELSE");
            botonContinuar.gameObject.SetActive(true);
        }
    }


    public void SalirDelJuego()
    {
        myAudio.PlayOneShot(interfz);
        Application.Quit();
    }

    public void Controles()
    {
        if (ControlesActivos == false)
        {
            myAudio.PlayOneShot(interfz);
            TextoControles.SetActive(true);
            ControlesActivos = true;
        }
        else if (ControlesActivos == true)
        {
            myAudio.PlayOneShot(interfz);
            TextoControles.SetActive(false);
            ControlesActivos = false;
        }
    }

    public void ClickedNewFile()
    {
        myAudio.PlayOneShot(interfz);
        SceneManager.LoadScene("SampleScene");
        PlayerPrefs.SetInt("continuar", 0);
        PlayerPrefs.SetInt("puntoControl", 0);

        PlayerPrefs.SetInt("maspp", 0);
        PlayerPrefs.SetInt("restos", 0);
        PlayerPrefs.SetInt("restos++", 0);
        PlayerPrefs.SetInt("ultrarestos", 0);
    }

    public void VolverAlMenu()
    {
        myAudio.PlayOneShot(interfz);
        SceneManager.LoadScene("MenuInicio");
    }

    public void Continuar()
    {
        PlayerPrefs.SetInt("continuar", 1);
        SceneManager.LoadScene("SampleScene");
    }
}