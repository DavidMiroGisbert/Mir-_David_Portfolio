using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //Movimiento Izquierda
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed, 0f, 0f) * Time.deltaTime);
        }

        //Movimiento Derecha
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed, 0f, 0f) * Time.deltaTime);
        }
    }
}