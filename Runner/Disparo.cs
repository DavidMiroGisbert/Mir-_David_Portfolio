using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    //Script para realizar el disparo de los misiles
    float fuerza = 10f; // fuerza del misil
    public GameObject misil;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Cañon", 2f, 2f);
    }
    
    void Cañon()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y+1.5f, transform.position.z); //posicion donde se instancia
        GameObject clon = Instantiate(misil, pos, gameObject.transform.rotation) as GameObject; //Instancia del clon del misil original
        clon.SetActive(true);

        rb = clon.GetComponent<Rigidbody>();

        Vector3 direccion = new Vector3(fuerza, 0f, 0f);
        rb.AddForce(direccion); //Movimiento bala
        
    }
}
