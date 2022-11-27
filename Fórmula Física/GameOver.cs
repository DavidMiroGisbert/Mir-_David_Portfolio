using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text TextoTiempo;
    public Text TextoEnemigos;
    

    //Muestra del tiempo y las bajas al terminar el juego
    void Start()
    {
        TextoTiempo.text = UIManager.time.ToString("f0");

        TextoEnemigos.text = PlayerController.enemigosMuertos.ToString();
    }
    
    public void Restart()
    {
        UIManager.time = 0;
        PlayerController.enemigosMuertos = 0;
        SceneManager.LoadScene("Canon 2");
    }   
}
