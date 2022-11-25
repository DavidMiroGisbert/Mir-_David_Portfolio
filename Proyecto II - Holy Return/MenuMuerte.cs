using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class MenuMuerte : MonoBehaviour
{
    //AUDIO
    AudioSource myAudio;
    public AudioClip interfz;
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    public void MenuPrincipal()
    {
        myAudio.PlayOneShot(interfz);
        SceneManager.LoadScene("MenuInicio");
    }

    public void Continuar()
    {
        if (PlayerPrefs.GetInt("puntoControl") == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {

            myAudio.PlayOneShot(interfz);
            PlayerPrefs.SetInt("continuar", 1);
            SceneManager.LoadScene("SampleScene");
        }
    }

    // Update is called once per frame

}
