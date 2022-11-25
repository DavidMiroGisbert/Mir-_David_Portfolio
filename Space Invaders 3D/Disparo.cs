using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public static bool disparar = true;
    public float fuerzabala = 2f;
    Rigidbody Balarb;
    float timeAux;
    public GameObject bala;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Instanciamiento de la bala cada vez que se pulsa el espacio
        float timeDif = Time.time - timeAux;
        if (Input.GetKeyDown(KeyCode.Space) && (disparar==true))
        {
            disparar = false;
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z);
            GameObject clon = Instantiate(bala, pos, Quaternion.identity) as GameObject;
            clon.SetActive(true);

            Balarb = clon.GetComponent<Rigidbody>();
            Vector3 direccionbala = new Vector3(0, fuerzabala, 0);
            Balarb.AddForce(direccionbala);
            timeAux = Time.time;
        }
    }
}
