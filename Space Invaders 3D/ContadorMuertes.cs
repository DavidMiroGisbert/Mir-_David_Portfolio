using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContadorMuertes : MonoBehaviour
{
    public static float score = 0; //Variable que suma los aliens matados
    public Text Puntos;
    public Text Victoria;
    public Image Imagen;
    public Button reinicio;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        Imagen.enabled = false;
        Victoria.enabled = false;
        Puntos.text = "Puntos: " + score; //Actualiza el texto de aliens muertos de la interfaz
    }

    // Update is called once per frame
    void Update()
    {
        Puntos.text = "Puntos: " + score;
        if (score>=56) //En caso de que se maten 56 aliens se gana la partida y aparecen los GameObjects del canvas correspondientes
        {
            Imagen.enabled =true;
            Victoria.enabled = true;
            reinicio.gameObject.SetActive(true);
        }
    }
}
