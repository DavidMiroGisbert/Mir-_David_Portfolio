using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPared : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        transform.Translate(-0.1f, 0f, 0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
}
