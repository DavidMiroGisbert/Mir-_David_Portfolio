using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public GameObject MartinHez;
    public float PosicionCombateX;
    public float PosicionCombateY;

    //COLISIONES
    //Rigidbody2D rb;

    //UI
    public Image barraDeVida;

    //CUALIDADES PERSONAJE
    public float health;
    public float Maxhealth;
    int ataqueBase;
    bool RecoilHuida = true;

    //VARIABLES MOVIMIENTO
    public int vel;
    float movvert;
    float movhoriz;

    //VARIABLES COMBATE
    public static bool ModoCombate;

    float contador;
    public Vector3 PosicionActual;

    public static bool Hab1Desbloqueada;

    bool EmpezarARecuperarVida = false;
    //public bool EnemyDeathPorCollider = false;

    public GameObject EnemigoCombateActual;
    public GameObject CombManager;

    //CAMARAS
    public GameObject MainCamera;
    public GameObject CamaraCombate;

    public static int danoAtaque;
    public static int danoGarra;
    public static int danoLluvia;

    //VARIABLES CAMBIO ANIMACION
    bool M_Front = true;
    Animator anim;

    //AUDIO
    AudioSource myAudio;
    public AudioClip CityTheme;
    public AudioClip BattleTheme1;
    public AudioClip itemsound;
    public AudioClip savesound;

    //INTERFAZ
    public Image getitem;
    public Image saved;
    public Text itemt;

    //Objetos
    public Objetos ObjetosScript;


    bool movPulsado;

    void Awake()
    {
        //rb = GetComponent<Rigidbody2D>(); 
        health = 100;
        Maxhealth = 100;
        ModoCombate = false;
        contador = 0.0f;
        Hab1Desbloqueada = false;
        CamaraCombate.SetActive(false);
        anim = GetComponent<Animator>();

        danoAtaque = 25;
        danoGarra = 50;
        danoLluvia = 75;

        myAudio = GetComponent<AudioSource>();

        movPulsado = false;
    }


    void Start()
    {
        PosicionCombateX = 208;
        PosicionCombateY = -112;
    }


    void Update()
    {
        //Vida de la UI
        barraDeVida.fillAmount = health / Maxhealth;
        contador = Time.deltaTime;

        if (ModoCombate == false)
        {
            movvert = Input.GetAxis("Vertical");
            movhoriz = Input.GetAxis("Horizontal");

            if (movvert != 0 || movhoriz != 0)
            {
                movPulsado = true;
            }


            //if (movvert > 0.1f || movvert < -0.1f || movhoriz > 0.1f || movhoriz < -0.1f)
            if (movvert == 0 && movhoriz == 0 && movPulsado == false)
            {
                anim.SetBool("Movimiento", false);
            }
            else
            {
                anim.SetBool("Movimiento", true);
            }

            anim.SetFloat("SpeedX", movhoriz);
            anim.SetFloat("SpeedY", movvert);
        }


        if (ModoCombate == false)
        {
            if (movvert != 0.0f)
            {
                transform.position += new Vector3(0.0f, movvert, 0.0f) * Time.deltaTime * vel;
            }
            else if (movhoriz != 0.0f)
            {
                transform.position += new Vector3(movhoriz, 0.0f, 0.0f) * Time.deltaTime * vel;
            }

            CombManager.GetComponent<CombatManager>().CanvasCombate.SetActive(false);
        }


        //Debug.Log(movJugador.Hab1Desbloqueada);

        if (Hab1Desbloqueada == true && health < 100 && ModoCombate == false)
        {
            Hab1Desbloqueada = false;
            HabilidadRecuperarVida();
        }
    }


    public void HabilidadHuir()
    {
        RecoilHuida = false;
        Debug.Log("Has huido del combate");
       //health = Maxhealth;
        gameObject.transform.position = PosicionActual;
        ModoCombate = false;
        GiroCombate();
        CamaraCombate.SetActive(false);
        CombManager.GetComponent<CombatManager>().CanvasCombate.SetActive(false);
        CombManager.GetComponent<CombatManager>().enemigoMuerto=true;
        MainCamera.SetActive(true);
        CombManager.GetComponent<CombatManager>().DestruirEnemiesHuida();
        StartCoroutine("recoilHuir");

    }
    IEnumerator recoilHuir()
    {
        yield return new WaitForSeconds(2f);
        RecoilHuida = true;
    }


    public void HabilidadRecuperarVida()
    {
        StartCoroutine("RecuperacionDeVida");
    }


    IEnumerator RecuperacionDeVida()
    {
        if (health <= 90)
        {
            health = health + 10;
            Debug.Log("VIDA DEL PERSONAJE: " + health);
            yield return new WaitForSeconds(3f);
            HabilidadRecuperarVida();
        }

        else if (health > 90 && health < 100)
        {
            health = 100;
            Hab1Desbloqueada = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Falta cambiar el transform.position para que vayan a diferentes puntos
        if ( collision.gameObject.tag == "EnemyAlcantarilla" && RecoilHuida==true)
        {
            EnemigoCombateActual = collision.gameObject;
            PosicionActual = new Vector3(transform.position.x, transform.position.y - 1f, 0f);
            ModoCombate = true;
            //EnemyDeathPorCollider = true;
            CombManager.GetComponent<CombatManager>().GenerarEnemigos();
            MainCamera.SetActive(false);
            transform.position = new Vector3(PosicionCombateX, PosicionCombateY, 0f);
            GiroCombate();
            CamaraCombate.SetActive(true);
        }
        else if (collision.gameObject.tag == "EnemyPlaya" && RecoilHuida == true)
        {
            EnemigoCombateActual = collision.gameObject;
            PosicionActual = new Vector3(transform.position.x, transform.position.y - 1f, 0f);
            ModoCombate = true;
            //EnemyDeathPorCollider = true;
            CombManager.GetComponent<CombatManager>().GenerarEnemigos();
            MainCamera.SetActive(false);
            transform.position = new Vector3(PosicionCombateX, PosicionCombateY, 0f);
            GiroCombate();
            CamaraCombate.SetActive(true);
        }
        else if (collision.gameObject.tag == "EnemyCiudad" && RecoilHuida == true)
        {
            EnemigoCombateActual = collision.gameObject;
            PosicionActual = new Vector3(transform.position.x, transform.position.y - 1f, 0f);
            ModoCombate = true;
            //EnemyDeathPorCollider = true;
            CombManager.GetComponent<CombatManager>().GenerarEnemigos();
            MainCamera.SetActive(false);
            transform.position = new Vector3(PosicionCombateX, PosicionCombateY, 0f);
            GiroCombate();
            CamaraCombate.SetActive(true);
        }
        else if (collision.gameObject.tag == "EnemyParque" && RecoilHuida == true)
        {
            EnemigoCombateActual = collision.gameObject;
            PosicionActual = new Vector3(transform.position.x, transform.position.y - 1f, 0f);
            ModoCombate = true;
            //EnemyDeathPorCollider = true;
            CombManager.GetComponent<CombatManager>().GenerarEnemigos();
            MainCamera.SetActive(false);
            transform.position = new Vector3(PosicionCombateX, PosicionCombateY, 0f);
            GiroCombate();
            CamaraCombate.SetActive(true);
        }

        // Bosses
        if (collision.gameObject.tag == "BossAlcantarilla" && RecoilHuida == true)
        {
            CombManager.GetComponent<CombatManager>().BossEnEscena = GameObject.FindGameObjectWithTag("BossAlcantarilla");
            EnemigoCombateActual = collision.gameObject;
            PosicionActual = new Vector3(transform.position.x, transform.position.y - 1f, 0f);
            ModoCombate = true;
            //EnemyDeathPorCollider = true;
            CombManager.GetComponent<CombatManager>().InstanciarBoss();
            MainCamera.SetActive(false);
            transform.position = new Vector3(PosicionCombateX, PosicionCombateY, 0f);
            GiroCombate();
            CamaraCombate.SetActive(true);
        }
        if (collision.gameObject.tag == "BossPlaya" && RecoilHuida == true)
        {
            CombManager.GetComponent<CombatManager>().BossEnEscena = GameObject.FindGameObjectWithTag("BossPlaya");
            EnemigoCombateActual = collision.gameObject;
            PosicionActual = new Vector3(transform.position.x, transform.position.y - 1f, 0f);
            ModoCombate = true;
            //EnemyDeathPorCollider = true;
            CombManager.GetComponent<CombatManager>().InstanciarBoss();
            MainCamera.SetActive(false);
            transform.position = new Vector3(PosicionCombateX, PosicionCombateY, 0f);
            GiroCombate();
            CamaraCombate.SetActive(true);
        }
        if (collision.gameObject.tag == "BossCiudad" && RecoilHuida == true)
        {
            CombManager.GetComponent<CombatManager>().BossEnEscena = GameObject.FindGameObjectWithTag("BossCiudad");
            EnemigoCombateActual = collision.gameObject;
            PosicionActual = new Vector3(transform.position.x, transform.position.y - 1f, 0f);
            ModoCombate = true;
            //EnemyDeathPorCollider = true;
            CombManager.GetComponent<CombatManager>().InstanciarBoss();
            MainCamera.SetActive(false);
            transform.position = new Vector3(PosicionCombateX, PosicionCombateY, 0f);
            GiroCombate();
            CamaraCombate.SetActive(true);
        }
        if (collision.gameObject.tag == "BossParque" && RecoilHuida == true)
        {
            CombManager.GetComponent<CombatManager>().BossEnEscena = GameObject.FindGameObjectWithTag("BossParque");
            EnemigoCombateActual = collision.gameObject;
            PosicionActual = new Vector3(transform.position.x, transform.position.y - 1f, 0f);
            ModoCombate = true;
            //EnemyDeathPorCollider = true;
            CombManager.GetComponent<CombatManager>().InstanciarBoss();
            MainCamera.SetActive(false);
            transform.position = new Vector3(PosicionCombateX, PosicionCombateY, 0f);
            GiroCombate();
            CamaraCombate.SetActive(true);
        }
        if (collision.gameObject.tag == "BossFinal" && RecoilHuida == true)
        {
            CombManager.GetComponent<CombatManager>().BossEnEscena = GameObject.FindGameObjectWithTag("BossFinal");
            EnemigoCombateActual = collision.gameObject;
            PosicionActual = new Vector3(transform.position.x, transform.position.y - 1f, 0f);
            ModoCombate = true;
            //EnemyDeathPorCollider = true;
            CombManager.GetComponent<CombatManager>().InstanciarBoss();
            MainCamera.SetActive(false);
            transform.position = new Vector3(PosicionCombateX, PosicionCombateY, 0f);
            GiroCombate();
            CamaraCombate.SetActive(true);
        }

        //Trigger Metro
        if (collision.gameObject.tag == "MetroAlcantarilla")
        {
            transform.position = new Vector3(123f, -66f, 0f);
        }
        if (collision.gameObject.tag == "MetroCiudad")
        {
            transform.position = new Vector3(-14.1f, 29.4f, 0f);
            MainCamera.SetActive(true);
        }

        //AudioCombate
        if (collision.gameObject.tag == "combate")
        {
            myAudio.Stop();
            myAudio.PlayOneShot(BattleTheme1);
        }

        //Items
        if (collision.gameObject.tag == "Restos")
        {
            getitem.gameObject.SetActive(true);
            itemt.text = "Restos";
            myAudio.PlayOneShot(itemsound);
            ObjetosScript.objetos_lista[0]++;
            Destroy(collision.gameObject);
            StartCoroutine("QuitarCarteles");
        }
        if (collision.gameObject.tag == "Restos++")
        {
            getitem.gameObject.SetActive(true);
            itemt.text = "Restos++";
            myAudio.PlayOneShot(itemsound);
            ObjetosScript.objetos_lista[1]++;
            Destroy(collision.gameObject);
            StartCoroutine("QuitarCarteles");
        }
        if (collision.gameObject.tag == "UltraRestos")
        {
            getitem.gameObject.SetActive(true);
            itemt.text = "Ultra Restos";
            myAudio.PlayOneShot(itemsound);
            ObjetosScript.objetos_lista[2]++;
            Destroy(collision.gameObject);
            Debug.Log("Hola");
            StartCoroutine("QuitarCarteles");
        }
        if (collision.gameObject.tag == "RolloPapel")
        {
            getitem.gameObject.SetActive(true);
            itemt.text = "Mas PP";
            myAudio.PlayOneShot(itemsound);
            ObjetosScript.objetos_lista[3]++;
            Destroy(collision.gameObject);
            StartCoroutine("QuitarCarteles");
        }
        if (collision.gameObject.tag == "Guardarpartida")
        {
            myAudio.PlayOneShot(savesound);
            saved.gameObject.SetActive(true);
            StartCoroutine("QuitarCarteles");
        }

    }


    IEnumerator QuitarCarteles()
    {
        yield return new WaitForSeconds(2.5f);
        getitem.gameObject.SetActive(false);
        saved.gameObject.SetActive(false);
        itemt.text = "";
    }


    public void GiroCombate()
    {
        movPulsado = false;
        if (M_Front == true)
        {
            anim.SetBool("CambioBack", true);
            M_Front = false;
        }
        else
        {
            anim.SetBool("CambioBack", false);
            M_Front = true;
        }
    }
}