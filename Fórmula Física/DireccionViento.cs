using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DireccionViento : MonoBehaviour
{
    public GameObject viento;
    public GameObject bandera;
    public float direccion;
    
    void Start()
    {
        direccion = viento.GetComponent<CanonProperties>().BetaW;
        Vector3 angulo = new Vector3(0, direccion, 0);
        Vector3 angulo2 = new Vector3(0, direccion + 0.5f, 0);
        //Se traza un vector con las coordenadas ofrecidas por angulo y angulo2 y de esta forma muestra la dirección del viento
        bandera.transform.eulerAngles = Vector3.Lerp(angulo, angulo2, Time.deltaTime);
    }

   
    void Update()
    {
        direccion = viento.GetComponent<CanonProperties>().BetaW;
        Vector3 angulo = new Vector3(0, direccion, 0);
        Vector3 angulo2 = new Vector3(0, direccion + 0.5f, 0);

        //Correción del ángulo para evitar angulos negativos
        if (angulo.y < 0)
        {
            angulo.y = angulo.y + 360;
        }
        //Se traza un vector con las coordenadas ofrecidas por angulo y angulo2 y de esta forma muestra la dirección del viento
        bandera.transform.eulerAngles = Vector3.Lerp(angulo, angulo2, Time.deltaTime);
      
    }
}
