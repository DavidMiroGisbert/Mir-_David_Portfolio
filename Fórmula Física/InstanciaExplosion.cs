using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciaExplosion : MonoBehaviour
{
    public GameObject explosion;
    

   
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && CanonProperties.puedoDisparar == true) //Instancia la particula de explosion cuando se pueda disparar
        { 
            Instantiate(explosion, transform.position, Quaternion.identity);
           
        }
    }
}
