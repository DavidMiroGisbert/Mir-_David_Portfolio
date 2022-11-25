using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento adelante
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0f, 0f, speed) * Time.deltaTime);
        }

        //Movimiento atrás
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0f, 0f, -speed) * Time.deltaTime);
        }
        //Movimiento izquierda
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed, 0f, 0f) * Time.deltaTime);
        }

        //Movimiento derecha
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed, 0f, 0f) * Time.deltaTime);
        }
    }
}
