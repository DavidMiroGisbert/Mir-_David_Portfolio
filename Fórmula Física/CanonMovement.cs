using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonMovement : MonoBehaviour
{
    float girar = 40;
    public GameObject Eje;
    public static float Sensibilidad_0_1 = 0.5f;
    public static bool canonRecto;
    
    void Start()
    {
        canonRecto = false;
    }

   
    void Update()
    {
        if (canonRecto == true)
        {
            Eje.transform.Rotate(Vector3.zero); //Rota desde el mundo del juego
        }
        //Limite del cañón, solo mitad superior
        if (Eje.transform.localEulerAngles.x <= 80)
        {
            MoveX();
        }

        else if (Eje.transform.localEulerAngles.x > 80 && Eje.transform.localEulerAngles.x < 85)
        {
            if (Input.GetKey(KeyCode.S) && UI.HASGANAO == false && UI.HASPERDIDO == false)
            {
                Eje.transform.Rotate(-girar * Time.deltaTime - Sensibilidad_0_1, 0, 0);
            }
        }
        if (Eje.transform.localEulerAngles.x > 350 && Eje.transform.localEulerAngles.x < 360)
        {
            if (Input.GetKey(KeyCode.W) && UI.HASGANAO == false && UI.HASPERDIDO == false)
            {
                Eje.transform.Rotate(girar * Time.deltaTime + Sensibilidad_0_1, 0, 0);
            }
        }

        MoveY();

    }
    //Movimiento rotación Vertical
    public void MoveY()
    {
        if (Input.GetKey(KeyCode.A) && UI.HASGANAO == false && UI.HASPERDIDO == false)
        {

            Eje.transform.Rotate(0, -girar * Time.deltaTime - Sensibilidad_0_1, 0, Space.World); //Rota desde el mundo del juego
        }

        if (Input.GetKey(KeyCode.D) && UI.HASGANAO == false && UI.HASPERDIDO == false)
        {
            Eje.transform.Rotate(0, girar * Time.deltaTime + Sensibilidad_0_1, 0, Space.World);
        }
    }

    //Movimiento rotación horizontal
    public void MoveX()
    {
        if (Input.GetKey(KeyCode.S) && UI.HASGANAO == false && UI.HASPERDIDO == false)
        {
            Eje.transform.Rotate(-girar * Time.deltaTime - Sensibilidad_0_1, 0, 0);
        }

        if (Input.GetKey(KeyCode.W) && UI.HASGANAO == false && UI.HASPERDIDO == false)
        {
            Eje.transform.Rotate(girar * Time.deltaTime + Sensibilidad_0_1, 0, 0);
        }
    }


}
