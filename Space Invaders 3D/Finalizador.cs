using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finalizador : MonoBehaviour
{
    //GameObjects que aparecen una vez finaliza la partida
    public Image Imagen;
    public Text GameOver;
    public Text Victoria;
    public Button reiniciar;


    // Start is called before the first frame update
    void Start()
    {
        //Inicializados a false para que no aparezcan
        GameOver.enabled = false;
        Imagen.enabled = false;
        Victoria.enabled = false;
      
    }
    void OnTriggerEnter(Collider collision)
    {
       
            if (collision.gameObject.tag == "muerte") //En caso de que les alcanze una bala se destruye el alien
            {
            Destroy(gameObject);
            
            }
            if (collision.gameObject.tag == "derrota") //En caso de que el alien llegue al límite inferior, se termina la partida
            {
            //Pasan a true para que aparezcan in-game
                GameOver.enabled = true;
                Imagen.enabled = true;
                reiniciar.gameObject.SetActive(true);
            }

        
    }
        // Update is called once per frame
        void Update()
        {
        
       
        }
}
