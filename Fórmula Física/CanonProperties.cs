using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonProperties : MonoBehaviour
{
    public List<GameObject> Lista1 = new List<GameObject>();

    //Movimiento canon
    public float girar;

    //Disparo Canon
    public static bool puedoDisparar;
    public static bool balaDestruida;
    int tipoBala;
    public static float dañoBala;

    //Referencias
    public GameObject Canon;
    public GameObject spawnerchungo;
    public GameObject Eje;
    public Resistencia_Aire Aire;


    //Instanciar bala
    public float Vm; //velocidad inicial
    public float Alpha; //angulo x
    public float Gamma; //angulo y
    public float L; //Longitud canon
    float Gravedad = 40;
    public float Ti; //Tiempo incremental

    //Fórmula
    public float masa = 2;
    public float Cd = 1f;
    public float Vw = 0;
    public float Cw = 1f;
    public float BetaW = 0;

    float Sen_Angulo_Viento;

    float Cos_Angulo_Viento;

    public static int contadorDisparos = 0;
    public static bool cambioDireccion = false;



    public IEnumerator RandomizeAir() //Cambio de la direccion del viento
    {
        Cd = Random.Range(0.9f, 1f);
        Vw = Random.Range(1f, 9f);
        Cw = Random.Range(0.9f, 1f);
        BetaW = Random.Range(0f, 359f);

        cambioDireccion = true;
        yield return new WaitForSeconds(0.5f);
        cambioDireccion = false;
    }


    //posición de la bala
    public float Lx;
    public float Ly;
    public float Lz;

    // simulation
    public float Yb = 8;

    public float b;

    public List <GameObject>  bala;
    //public Transform Shotpoint;
    
   
    //Ángulos respecto al eje
    float Omegax;
    float Omegay;
    float Omegaz;

    
    public Transform character;

    [Header("Audio Bala")]
    public AudioSource audiobalas;
    public AudioClip clip;


    private void Start()
    {
        puedoDisparar = true;

        Cd = Random.Range(0.9f, 1f);
        Vw = Random.Range(1f, 9f);
        Cw = Random.Range(0.9f, 1f);
        BetaW = Random.Range(0f, 359f);


        tipoBala = 0;
        masa = 2;
        dañoBala = 1;
    }

    void Update()
    {
        Alpha = Eje.transform.localEulerAngles.x ;
        Gamma = Eje.transform.localEulerAngles.y ;
        //Cambio de aire según la dificultad elegida 
        if (Dificultades.facil == true)
        {
            if (contadorDisparos == 10)
            {
                contadorDisparos = 0;
                StartCoroutine("RandomizeAir");

            }
        }
        else if (Dificultades.normal == true)
        {
            if (contadorDisparos == 8)
            {
                contadorDisparos = 0;
                StartCoroutine("RandomizeAir");

            }
        }
        else if (Dificultades.dificil == true)
        {
            if (contadorDisparos == 5)
            {
                contadorDisparos = 0;
                StartCoroutine("RandomizeAir");

            }
        }
        else
        {
            if (contadorDisparos == 1)
            {
                contadorDisparos = 0;
                StartCoroutine("RandomizeAir");

            }
        }
       

       
        //Input para instanciar
        if (Input.GetKeyUp(KeyCode.Space) && UI.HASGANAO == false && UI.HASPERDIDO == false && puedoDisparar==true)
        {
            //Generar sonido
            audiobalas.PlayOneShot(audiobalas.clip);
            puedoDisparar = false;
            balaDestruida = false;
            Instantiate();
            contadorDisparos++;
        }
        //Movimiento bala
        disparo();

        //Cambio entre municiones
        CambioBala();
    }

    void CambioBala()
    {
        //Bala ligera
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            tipoBala = 0;
            masa = 6;
            dañoBala = 1;
        }

        //Bala media
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            tipoBala = 1;
            masa = 8;
            dañoBala = 2;
        }

        //Bala pesada
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            tipoBala = 2;
            masa = 10;
            dañoBala = 3;
        }
    }

    public void disparo()
    { for (int i = 0; i < Lista1.Count; i++)
        {
            GameObject proyectil = Lista1[i];
            Vectores position = Simulation(proyectil.GetComponent<Bala>(), Time.deltaTime);

            if (balaDestruida==true)
            {
                Lista1.Remove(proyectil);
                Destroy(proyectil);
                puedoDisparar = true;
            }

            if (proyectil.GetComponent<Bala>().Tinc >= 4)
            {
                Lista1.Remove(proyectil);
                Destroy(proyectil);
                puedoDisparar = true;
            }
            else
            {

                proyectil.transform.position = position.tovector3(); 
            }
        }
    }

    
    public void Instantiate()
    {


        Vm = Barrafuerza.Valorfuerza;
        GameObject clon = Instantiate(bala[tipoBala]);
       

        // Asignación de las variables de la bala
        clon.GetComponent<Bala>().Alpha = Alpha;
        clon.GetComponent<Bala>().Gamma = Gamma;
        clon.GetComponent<Bala>().G = Gravedad;
        clon.GetComponent<Bala>().Tinc = Ti;
        clon.GetComponent<Bala>().posInit = spawnerchungo.transform.position;
        clon.GetComponent<Bala>().Vm = Vm;
        clon.GetComponent<Bala>().Vw = Vw;
        clon.GetComponent<Bala>().BetaW = BetaW;
        clon.GetComponent<Bala>().Cd = Cd;
        clon.GetComponent<Bala>().Cw = Cw;
        clon.GetComponent<Bala>().masa_bala = masa;
        clon.GetComponent<Bala>().masa_bala = dañoBala;
        


        Lista1.Add(clon);
         
        
       
    }
    
    //Fórmulas para calcular la trayectoria de la bala
    public Vectores Simulation(Bala proyectil, float dTime)
    {
        b = L * Mathf.Cos((90 - proyectil.Alpha) * (Mathf.PI / 180f));
        Lz = b * Mathf.Cos((proyectil.Gamma) * (Mathf.PI / 180f));  
        Ly = L * Mathf.Cos((proyectil.Alpha) * (Mathf.PI / 180f)); 
        Lx = b * Mathf.Sin((proyectil.Gamma) * (Mathf.PI / 180f)); 

        Omegax = Lx / L;
        Omegay = Ly / L;
        Omegaz = Lz / L;

        Sen_Angulo_Viento = Mathf.Sin((proyectil.BetaW) * (Mathf.PI / 180f));

        Cos_Angulo_Viento = Mathf.Cos((proyectil.BetaW) * (Mathf.PI / 180f));

        Vectores u = new Vectores();

        float Ax = proyectil.posInit.x + (proyectil.Vm * Omegax) * proyectil.Tinc;
        float Ay = (Yb + proyectil.posInit.y) + (proyectil.Vm * Omegay) * proyectil.Tinc - 1f / 2f * proyectil.G * Mathf.Pow(proyectil.Tinc, 2f);
        float Az = proyectil.posInit.z + (proyectil.Vm * Omegaz) * proyectil.Tinc;

        float Vx = proyectil.Vm * Omegax;
        float Vy = proyectil.Vm * Omegay;
        float Vz = proyectil.Vm * Omegaz;

        //Tiempo incremental
        proyectil.Tinc += dTime;

        //Fórmulas cinemática con aplicación del viento
        
            u.x = proyectil.posInit.x + (proyectil.masa_bala / proyectil.Cd * Mathf.Exp(-proyectil.Cd / proyectil.masa_bala * proyectil.Tinc) * (-proyectil.Cw * proyectil.Vw * Sen_Angulo_Viento / proyectil.Cd - Vx) - (proyectil.Cw * proyectil.Vw * Sen_Angulo_Viento / proyectil.Cd * proyectil.Tinc)) - (proyectil.masa_bala / proyectil.Cd * (-proyectil.Cw * proyectil.Vw * Sen_Angulo_Viento / proyectil.Cd - Vx));

            u.y = proyectil.posInit.y + (-(Vy + proyectil.masa_bala * Gravedad / proyectil.Cd) * proyectil.masa_bala / proyectil.Cd * Mathf.Exp(-proyectil.Cd / proyectil.masa_bala * proyectil.Tinc) - proyectil.masa_bala * Gravedad / proyectil.Cd * proyectil.Tinc) + (proyectil.masa_bala / proyectil.Cd * (proyectil.masa_bala * Gravedad / proyectil.Cd + Vy));

            u.z = proyectil.posInit.z + (proyectil.masa_bala / proyectil.Cd * Mathf.Exp(-proyectil.Cd / proyectil.masa_bala * proyectil.Tinc) * (-proyectil.Cw * proyectil.Vw * Cos_Angulo_Viento / proyectil.Cd - Vz) - (proyectil.Cw * proyectil.Vw * Cos_Angulo_Viento / proyectil.Cd * proyectil.Tinc)) - (proyectil.masa_bala / proyectil.Cd * (-proyectil.Cw * proyectil.Vw * Cos_Angulo_Viento / proyectil.Cd - Vz));



        return u;
    }

    


}
