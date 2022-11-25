using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangramManager : MonoBehaviour
{
    public RectTransform[] piezas = new RectTransform[7]; //ARRAY DE TODAS LAS PIEZAS
    private Vector3[] posicionesPiezas = new Vector3[7]; //ARRAY QUE GUARDA LAS POSICIONES DE LAS PIEZAS
    private Vector3[] rotacionPiezas = new Vector3[7]; //ARRAY QUE GUARDA LAS ROTACIONES DE LAS PIEZAS 
    public AudioSource pieceSelectedSound; //SONIDO AL PULSAR EL BOTON DE REINICIAR
    
    // Start is called before the first frame update
    void Start()
    {
        //--------------------OBTENCI�N DE LOS VALORES DE POSICI�N Y ROTACI�N DE LAS PIEZAS DEL JUGADOR--------------------//
        for (int i = 0; i < piezas.Length; i++)
        {
            posicionesPiezas[i] = piezas[i].position;
            rotacionPiezas[i] = piezas[i].eulerAngles;
        }
    }
    //--------------------FUNCI�N DONDE SE REINICIA LA POSICI�N DE LAS PIEZAS--------------------//
    public void ResetPosition()
    {
        pieceSelectedSound.Play();

        for (int i = 0; i < piezas.Length; i++)
        {
            piezas[i].position = posicionesPiezas[i];
            piezas[i].eulerAngles = rotacionPiezas[i];
        }
    }
}
