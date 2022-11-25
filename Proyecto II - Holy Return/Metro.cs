using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metro : MonoBehaviour
{
    public Transform cityentry;
    public Transform alcentry;
    public Transform playaentry;
    public Transform parkentry;
    public Transform casaentry;
    public Transform cityexit;
    public Transform alcexit;
    public Transform playaexit;
    public Transform parkexit;
    public Transform casaexit;

    //ESTACIONES BLOQUEADAS DE ENTRADA O PARA VIAJAR
    public bool aceso1 = false;
    public bool aceso2 = false;
    public bool aceso3 = false;
    public bool aceso4 = false;

    public int acceso1int = 0;
    public int acceso2int = 0;
    public int acceso3int = 0;
    public int acceso4int = 0;

    public bool metropass = false;
    Vector3 Vectorz = new Vector3(0f, 0f, 1166f);
    Vector3 Vectory = new Vector3(0f, -3f, 1166f);
    Vector3 Vectoryplaya = new Vector3(0f, -3f, 1090f);
    Vector3 Vectorycity = new Vector3(0f, -3f, 1089f);

    //Evitar viajar a la estacion que ya estas
    bool a1 = false;
    bool p1 = false;
    bool c1 = false;
    bool p2 = false;
    bool c2 = false;

    //CAMARAS
    public GameObject MainCamera;
    public GameObject CamaraAlcantarillas;
    public GameObject CamaraPlaya;
    public GameObject CamaraParque;
    public GameObject CamaraCasa;
    public GameObject CamaraCiudad;




    // Start is called before the first frame update

    void Awake()
    {
        CamaraAlcantarillas.SetActive(false);
        CamaraPlaya.SetActive(false);
        CamaraParque.SetActive(false);
        CamaraCasa.SetActive(false);
        CamaraCiudad.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1") && metropass == true)
        {
            Alcantarillas();
        }
        else if (Input.GetKeyDown("2") && metropass == true)
        {
            Playa();
        }
        else if (Input.GetKeyDown("3") && metropass == true)
        {
            Ciudad();
        }
        else if (Input.GetKeyDown("4") && metropass == true)
        {
            Parque();
        }
        else if (Input.GetKeyDown("5") && metropass == true)
        {
            Casa();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MetroExit")
        {
            gameObject.transform.position = cityentry.transform.position+ Vectorycity;
            CamaraCiudad.SetActive(false);
            MainCamera.SetActive(true);
        }
        else if (collision.gameObject.tag == "MetroEntry")
        {
            gameObject.transform.position = cityexit.transform.position + Vectorz;
            CamaraCiudad.SetActive(true);
            MainCamera.SetActive(false);
            aceso1 = true;
            acceso1int = 1;
            aceso2 = true;
            acceso2int = 1;
            c1 = true;

            p1 = false;
            a1 = false;
            c2 = false;
            p2 = false;
        }
        else if (collision.gameObject.tag == "MetroEntryC")
        {
            gameObject.transform.position = casaexit.transform.position + Vectorz;
            CamaraCasa.SetActive(true);
            MainCamera.SetActive(false);
            aceso4 = true;
            acceso4int = 1;
            c2 = true;

            p1 = false;
            a1 = false;
            c1 = false;
            p2 = false;
        }
        else if (collision.gameObject.tag == "MetroExitC")
        {
            gameObject.transform.position = casaentry.transform.position + Vectory;
            CamaraCasa.SetActive(false);
            MainCamera.SetActive(true);
        }
        else if (collision.gameObject.tag == "MetroEntryPrk")
        {
            gameObject.transform.position = parkexit.transform.position + Vectorz;
            CamaraParque.SetActive(true);
            MainCamera.SetActive(false);
            aceso3 = true;
            acceso3int = 1;
            p2 = true;

            p1 = false;
            a1 = false;
            c2 = false;
            c1 = false;

        }
        else if (collision.gameObject.tag == "MetroExitPrk")
        {
            gameObject.transform.position = parkentry.transform.position + Vectory;
            CamaraParque.SetActive(false);
            MainCamera.SetActive(true);
        }
        else if (collision.gameObject.tag == "MetroEntryPl" && aceso2==true)
        {
            gameObject.transform.position = playaexit.transform.position + Vectorz;
            CamaraPlaya.SetActive(true);
            MainCamera.SetActive(false);
            p1 = true;

            c1 = false;
            a1 = false;
            c2 = false;
            p2 = false;

        }
        else if (collision.gameObject.tag == "MetroExitPl")
        {
            gameObject.transform.position = playaentry.transform.position + Vectoryplaya;
            CamaraPlaya.SetActive(false);
            MainCamera.SetActive(true);
        }
        else if (collision.gameObject.tag == "MetroEntryA" &&aceso1==true)
        {
            gameObject.transform.position = alcexit.transform.position + Vectorz;
            CamaraAlcantarillas.SetActive(true);
            MainCamera.SetActive(false);
            
        }
        else if (collision.gameObject.tag == "MetroExitA")
        {
            gameObject.transform.position = alcentry.transform.position+Vectoryplaya;
            CamaraAlcantarillas.SetActive(false);
            MainCamera.SetActive(true);
        }

        else if (collision.gameObject.tag == "estaciona1")
        {
            a1 = true;
            p1 = false;
            c1 = false;
            c2 = false;
            p2 = false;
        }
        else if (collision.gameObject.tag == "estacionp1")
        {
            a1 = false;
            p1 = true;
            c1 = false;
            c2 = false;
            p2 = false;
        }
        else if (collision.gameObject.tag == "estacionc1")
        {
            a1 = false;
            p1 = false;
            c1 = true;
            c2 = false;
            p2 = false;
        }
        else if (collision.gameObject.tag == "estacionp2")
        {
            a1 = false;
            p1 = false;
            c1 = false;
            c2 = false;
            p2 = true;
        }
        else if (collision.gameObject.tag == "estacionc2")
        {
            a1 = false;
            p1 = false;
            c1 = false;
            c2 = true;
            p2 = false;
        }
    }

    public void Alcantarillas()
    {

        if (a1 == false)
        {
            gameObject.transform.position = alcexit.transform.position + Vectorz;
            CamaraAlcantarillas.SetActive(true);
            MainCamera.SetActive(false);
            CamaraCiudad.SetActive(false);
            CamaraPlaya.SetActive(false);
            CamaraParque.SetActive(false);
            CamaraCasa.SetActive(false);
        }
       
    }
    public void Playa()
    {
        if (p1 == false)
        {
            gameObject.transform.position = playaexit.transform.position + Vectorz;
            CamaraPlaya.SetActive(true);
            MainCamera.SetActive(false);

            CamaraCiudad.SetActive(false);
            CamaraAlcantarillas.SetActive(false);
            CamaraParque.SetActive(false);
            CamaraCasa.SetActive(false);
        }
       
    }
    public void Ciudad()
    {
        if(c1==false)
        {
            gameObject.transform.position = cityexit.transform.position + Vectorz;
            CamaraCiudad.SetActive(true);
            MainCamera.SetActive(false);

            CamaraPlaya.SetActive(false);
            CamaraAlcantarillas.SetActive(false);
            CamaraParque.SetActive(false);
            CamaraCasa.SetActive(false);
        }
        
    }
    public void Parque()
    {
        if (aceso3 == true && p2==false)
        {
            gameObject.transform.position = parkexit.transform.position + Vectorz;
            CamaraParque.SetActive(true);
            MainCamera.SetActive(false);

            CamaraPlaya.SetActive(false);
            CamaraAlcantarillas.SetActive(false);
            CamaraCiudad.SetActive(false);
            CamaraCasa.SetActive(false);
        }
        
    }
    public void Casa()
    {
        if (aceso4 == true && c2 == false)
        {
            gameObject.transform.position = casaexit.transform.position + Vectorz;
            CamaraCasa.SetActive(true);
            MainCamera.SetActive(false);

            CamaraPlaya.SetActive(false);
            CamaraAlcantarillas.SetActive(false);
            CamaraCiudad.SetActive(false);
            CamaraParque.SetActive(false);
        }
        
    }
}
