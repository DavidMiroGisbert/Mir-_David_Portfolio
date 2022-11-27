using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo_Movimiento : MonoBehaviour
{
    //Script que cambia entre el movimiento del barco y el movimiento del cañón
    public CanonMovement Cannon;
    public PlayerMovement Barco;

    //variables para activar y desactivar las cámaras del juego
    public Camera Cm_Boat;
    public Camera Cm_Canon;

    // Start is called before the first frame update
    void Start()
    {
        Cannon.enabled = false;
        Barco.enabled = true;
        Cm_Canon.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))  //Cuando se pulsa la tecla Q, activará la 2nd cámara y desactivala 1era cámara y viceversa
        {
            Barco.enabled =! (Barco.enabled);
            Cannon.enabled =!(Cannon.enabled);
            Cm_Canon.enabled =!(Cm_Canon.enabled);
            Cm_Boat.enabled =!(Cm_Boat.enabled);
            CanonMovement.canonRecto =! (CanonMovement.canonRecto);

        }
    }
}
