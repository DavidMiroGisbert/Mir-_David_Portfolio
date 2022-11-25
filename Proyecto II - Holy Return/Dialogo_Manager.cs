using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogo_Manager : MonoBehaviour
{
    public Metro metro; //Permite usar el metro al cambiar una de sus boleanas
    public Dialogo dialogo;
    public CombatManager CM_Script;

    //Objetos
    public Objetos ObjetosScript; //Para la recompensa de Tokola


    //VARIABLES GUARDADO
    public int TokolaDestruida = 0;
    public int BrayanDestruido = 0;

    public int BucketDestruido = 0;
    public int HormigaDestruida = 0;
    public int DiegoDestruido = 0;
    public int HotPacoDestruido = 0;
    //public Guardado Guardado_Script;

    //ELEMENTOS DEL DIALOGO
    Queue<string> frases;

    public GameObject dialoguePanel;
    public GameObject speakerphoto;
    public GameObject speaker2;
    public TextMeshProUGUI displayText;

    //COLISIONES 
    public GameObject hormigacolision;
    public GameObject bucketcolision;
    public GameObject diegocolision;
    public GameObject hotpacocolision;
    public GameObject brayancolision;
    public GameObject tokolacolision;
    public GameObject culocolision;
    public GameObject trgpark;
    public GameObject trgreino;
    public GameObject trgcasa;

    //DIALOGOS +
    string activeSentence;
    public float Speed;
    public int textskipper=0;
    bool colOn = false;
    bool viaje = false;
    bool except = false;
    bool hornypaco = false;

    int contadorTokola = 0;
    int contadorBucket = 0;
    int contadorHormibuff = 0;
    int contadorDiego = 0;
    int contadorHotPaco = 0;


    //BOOLEANAS COMPAÑEROS
    public bool bucketpass = false;
    public bool hormipass = false;
    public bool diegopass = false;
    public bool hotpacopass = false;

    //OFFSETS CAMARA
    Vector3 Vectorz = new Vector3(0f, 0f, 1166f);
    Vector3 Vectory = new Vector3(0f, -3f, 1166f);
    Vector3 Vectoryplaya = new Vector3(0f, -3f, 1090f);
    Vector3 Vectorycity = new Vector3(0f, -3f, 1089f);

    //AUDIO DIALOGOS
    AudioSource myAudio;
    public AudioClip speakSound;
    public AudioClip reclutamiento;


    // Start is called before the first frame update
    void Start()
    {
        frases = new Queue<string>();
        myAudio = GetComponent<AudioSource>();
        speaker2.SetActive(false);
        speakerphoto.SetActive(false);
    }

    void Hablar() //ENTRADA
    {
        frases.Clear(); //Reinicio Conversaciones parte1

        foreach(string frase in dialogo.listafrases) //Busca todas las oraciones de ese listado pasandolas a frases para que una a una se añadan a la queue
        {
            frases.Enqueue(frase);
        }

        NextDialogue(); //Reinicio Conversaciones parte2
    }

    void NextDialogue() //Mostrar siguiente oración
    {
        if(frases.Count <= 0)
        {
            displayText.text = activeSentence;
            return; //Para que no siga avanzando en la funcion
            
        }
        else
        {
            activeSentence = frases.Dequeue();
            //Debug.Log(activeSentence);
            displayText.text = activeSentence;


                myAudio.clip = speakSound;
                myAudio.PlayOneShot(speakSound); //Sonido por frase
                StopAllCoroutines();
                StartCoroutine(EfectoLetra(activeSentence));
        }
    }

    IEnumerator EfectoLetra(string sentence) //Se muestran las letras 1 a 1 efecto retro
    {
        displayText.text = "";

        foreach(char letter in sentence.ToCharArray()){
            displayText.text += letter;
            //myAudio.PlayOneShot(speakSound); //Sonido por letra
            yield return new WaitForSeconds(Speed);
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            dialoguePanel.SetActive(true);
            speakerphoto.SetActive(true);
            Hablar();
            colOn = true;
        }
    }


    void OnTriggerExit2D(Collider2D other) //ABANDONAR DIALOGO
    {
        if (other.gameObject.tag == "Player")
        {
            dialoguePanel.SetActive(false);
            speakerphoto.SetActive(false);
            speaker2.SetActive(false);
            StopAllCoroutines();
            textskipper = 0;
            colOn = false;
            trgpark.SetActive(true);
            trgreino.SetActive(true);
            trgcasa.SetActive(true);
            metro.metropass = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && displayText.text == activeSentence)
        {
            textskipper += 1;
            NextDialogue();
        }

        if (dialogo.listafrases.Length > textskipper && colOn==true) //Cambios imagen locutor por turnos iguales
        {
            if (textskipper % 2 == 0)
            {
                speaker2.SetActive(false);
                speakerphoto.SetActive(true);

            }
            else if(textskipper % 2 != 0&& except==false)
            {
                speaker2.SetActive(true);
                speakerphoto.SetActive(false);
            }
            else
            {
                speaker2.SetActive(false);
                speakerphoto.SetActive(false);

            }
        }

        if (dialogo.locutor=="Hormibuff" && textskipper >= 12)
        {
            if (contadorHormibuff == 0)
            {
                myAudio.clip = reclutamiento;
                myAudio.volume = 0.3f;
                myAudio.PlayOneShot(reclutamiento); //Sonido por reclutar
                Invoke("DestroyerHormiga", 3f);
            }
            contadorHormibuff++;
        }

        else if (dialogo.locutor == "Diego" && textskipper >= 17)
        {
            if (contadorDiego == 0)
            {
                myAudio.clip = reclutamiento;
                myAudio.volume = 0.3f;
                myAudio.PlayOneShot(reclutamiento); //Sonido por reclutar
                Invoke("DestroyerDiego", 3f);
            }
            contadorDiego++;
        }

        else if (dialogo.locutor == "Bucket" && textskipper >= 12)
        {
            if (contadorBucket == 0)
            {
                myAudio.clip = reclutamiento;
                myAudio.volume = 0.3f;
                myAudio.PlayOneShot(reclutamiento); //Sonido por reclutar
                Invoke("DestroyerBucket", 3f);
            }
            contadorBucket++;
        }

        else if (dialogo.locutor == "Tokola" && textskipper >= 10)
        {
            if (contadorTokola == 0)
            {
                ObjetosScript.objetos_lista[0]++;
                ObjetosScript.objetos_lista[1]++;
                ObjetosScript.objetos_lista[2]++;
                ObjetosScript.objetos_lista[3]++;
            }
            contadorTokola++;
            Invoke("DestroyerTokola", 3f);
        }
        else if (dialogo.locutor == "Snakey" && textskipper >= 1)
        {

            metro.metropass = true;


        }
        else if (dialogo.locutor == "HotPaco" && textskipper >= 12)
        {
            if (contadorHotPaco == 0)
            {
                myAudio.clip = reclutamiento;
                myAudio.volume = 0.3f;
                myAudio.PlayOneShot(reclutamiento); //Sonido por reclutar
                trgpark.SetActive(true);
                Invoke("DestroyerPaco", 3f);
            }
            contadorHotPaco++;
        }
        else if (dialogo.locutor == "ReyKK" && textskipper >= 14)
        {
            trgpark.SetActive(true);

        }

        else if (dialogo.locutor == "Brayan" && textskipper >= 10)
        {
            Invoke("DestroyerBrayan", 3f);
        }

        else if (dialogo.locutor == "Culaso" && textskipper >= 12)
        {
            Invoke("DestroyerCulaso", 3f);
            trgcasa.SetActive(true);
        }
    }

    void DestroyerBucket()
    {
        gameObject.SetActive(false);
        Destroy(bucketcolision.gameObject); 
        bucketpass = true;
        CM_Script.GetComponent<CombatManager>().contadorCompanyeros++;
        BucketDestruido++;
        myAudio.clip = speakSound;
        myAudio.volume = 1f;
        except = true;
    }

    void DestroyerHormiga()
    {
        gameObject.SetActive(false);
        Destroy(hormigacolision.gameObject);
        hormipass = true;
        CM_Script.GetComponent<CombatManager>().contadorCompanyeros++;
        HormigaDestruida++;
        myAudio.clip = speakSound;
        myAudio.volume = 1f;
        except = true;
    }

    void DestroyerTokola()
    {
        gameObject.SetActive(false);
        Destroy(tokolacolision.gameObject);
        TokolaDestruida++;
        myAudio.clip = speakSound;
        myAudio.volume = 1f;
        except = true;
    }

    void DestroyerDiego()
    {
        gameObject.SetActive(false);
        Destroy(diegocolision.gameObject);
        diegopass = true;
        CM_Script.GetComponent<CombatManager>().contadorCompanyeros++;
        DiegoDestruido++;
        myAudio.clip = speakSound;
        myAudio.volume = 1f;
        except = true;
    }

    void DestroyerPaco()
    {
        gameObject.SetActive(false);
        Destroy(hotpacocolision.gameObject);
        hotpacopass = true;
        CM_Script.GetComponent<CombatManager>().contadorCompanyeros++;
        HotPacoDestruido++;
        myAudio.clip = speakSound;
        myAudio.volume = 1f;
        except = true;
    }

    void DestroyerBrayan()
    {
        gameObject.SetActive(false);
        Destroy(brayancolision.gameObject);
        BrayanDestruido++;
        myAudio.clip = speakSound;
        myAudio.volume = 1f;
        except = true;
    }

    void DestroyerCulaso()
    {
        gameObject.SetActive(false);
        Destroy(culocolision.gameObject);
        myAudio.clip = speakSound;
        myAudio.volume = 1f;
        except = true;
    }
}