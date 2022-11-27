using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

     float velocidad = 60f;

    public float gravedad = 9.8f;

    float Rotation_Rate = 40f;

    private Vector3 direccion = Vector3.zero;
  
    void Update()
    {  //Rotación para simular navegación del barco
        if (Input.GetKey(KeyCode.A)) //Izquierda
        {
            transform.RotateAround(transform.position, Vector3.up, -Rotation_Rate * Time.deltaTime);
            
        }


        else if (Input.GetKey(KeyCode.D)) //Derecha
        {

            transform.RotateAround(transform.position, Vector3.up, Rotation_Rate * Time.deltaTime);
        }
        CharacterController controller = GetComponent<CharacterController>();

        //Movimiento básico
        if (controller.isGrounded)
        {
            direccion = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            direccion = transform.TransformDirection(direccion);
            direccion *= velocidad;


        }
        direccion.y -= gravedad * Time.deltaTime;

        //Generar movimiento
        controller.Move(direccion * Time.deltaTime);
    }
}
