using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInstancia : MonoBehaviour
{
    public GameObject vida;
    public GameObject SpawnVida;

    public Transform[] posiciones;

    public float contador;

   
    void Start()
    {
        //Instanciar power up tras tiempo
        InvokeRepeating("spawn", 0f, contador);
    }

    //Instanciar power up de vida
    public void spawn()
    {
        if (PlayerController.vida < PlayerController.VidaMax) 
        {                 
            SpawnVida = Instantiate(vida, posiciones[Random.Range(0, posiciones.Length)].position, vida.transform.rotation);
        }      
    }
}
