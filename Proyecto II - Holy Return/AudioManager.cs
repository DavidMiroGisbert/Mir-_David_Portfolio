using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public CombatManager cm;
    public GameObject combatenormal;
    public GameObject boss1;
    public GameObject bossmed;
    public GameObject bosshard;
    public GameObject bossfinal;
    public GameObject trgpark;
    public GameObject trgreino;
    public GameObject trgcasa;
    public GameObject trgderrota;
    public GameObject trgvictoria;

    //AUDIO
    AudioSource myAudio;
    public AudioClip WastelandsTheme;
    public AudioClip BeachTheme;
    public AudioClip ParkTheme;
    public AudioClip CityTheme;
    public AudioClip HouseTheme;
    public AudioClip KakunaTheme;
    public AudioClip MetroTheme;
    public AudioClip BossEzTheme;
    public AudioClip BossMedTheme;
    public AudioClip BossHardTheme;
    public AudioClip BossFinalTheme;
    public AudioClip hothteme;
    public AudioClip culotheme;
    public AudioClip elrey;
    public AudioClip victoria;



    float startvolume;
    bool colision = false;


    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
       startvolume = myAudio.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (colision == false)
        {
            combatenormal.SetActive(true);
            boss1.SetActive(false);
            bossmed.SetActive(false);
            bosshard.SetActive(false);
            bossfinal.SetActive(false);
            
        }
        if (cm.wintheme == true)
        {
            trgvictoria.SetActive(true);
        }
        else if (cm.wintheme == false)
        {
            trgvictoria.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "alcantarillas")
        {
            StartCoroutine(FadeAudio(WastelandsTheme));
            

        }
        else if (collision.gameObject.tag == "playa")
        {
            StartCoroutine(FadeAudio(BeachTheme));
            
        }
        else if (collision.gameObject.tag == "reinokakuna")
        {
            StartCoroutine(FadeAudio(KakunaTheme));

        }
        else if (collision.gameObject.tag == "ciudad")
        {
            StartCoroutine(FadeAudio(CityTheme));

        }
        else if (collision.gameObject.tag == "parque")
        {
            StartCoroutine(FadeAudio(ParkTheme));

        }
        else if (collision.gameObject.tag == "casa")
        {
            StartCoroutine(FadeAudio(HouseTheme));

        }
        else if (collision.gameObject.tag == "metro")
        {
            StartCoroutine(FadeAudio(MetroTheme));

        }
        else if (collision.gameObject.tag == "HotPaco")
        {
            trgpark.SetActive(false);
            StartCoroutine(FadeAudio(hothteme));

        }
        else if (collision.gameObject.tag == "ReyKK")
        {
            trgreino.SetActive(false);
            StartCoroutine(FadeAudio(elrey));

        }
        else if (collision.gameObject.tag == "Culaso")
        {
            trgcasa.SetActive(false);
            StartCoroutine(FadeAudio(culotheme));

        }
        else if (collision.gameObject.tag == "Culaso")
        {
            trgcasa.SetActive(false);
            StartCoroutine(FadeAudio(culotheme));

        }
        else if (collision.gameObject.tag == "victoria")
        {
            StartCoroutine(FadeAudio(victoria));

        }

        else if(collision.gameObject.tag == "BossAlcantarilla")
        {
            combatenormal.SetActive(false);
            boss1.SetActive(true);
            bossmed.SetActive(false);
            bosshard.SetActive(false);
            bossfinal.SetActive(false);
            colision = true;


        }

        else if (collision.gameObject.tag == "Boss1Scenario")
        {
            StartCoroutine(FadeAudio(BossEzTheme));
        }

        else if (collision.gameObject.tag == "BossPlaya" || collision.gameObject.tag == "BossCiudad")
        {
            combatenormal.SetActive(false);
            boss1.SetActive(false);
            bossmed.SetActive(true);
            bosshard.SetActive(false);
            bossfinal.SetActive(false);
            colision = true;

        }

        else if (collision.gameObject.tag == "BossMedScenario")
        {
            StartCoroutine(FadeAudio(BossMedTheme));
        }

        else if (collision.gameObject.tag == "BossParque")
        {
            combatenormal.SetActive(false);
            boss1.SetActive(false);
            bossmed.SetActive(false);
            bosshard.SetActive(true);
            bossfinal.SetActive(false);
            colision = true;
        }
        else if (collision.gameObject.tag == "BossHardScenario")
        {
            StartCoroutine(FadeAudio(BossHardTheme));
        }
        else if (collision.gameObject.tag == "BossFinal")
        {
            combatenormal.SetActive(false);
            boss1.SetActive(false);
            bossmed.SetActive(false);
            bosshard.SetActive(false);
            bossfinal.SetActive(true);
            colision = true;
        }

        else if (collision.gameObject.tag == "BossFinalScenario")
        {
            StartCoroutine(FadeAudio(BossFinalTheme));
        }
        else if (collision.gameObject.tag == "EnemyAlcantarilla" || collision.gameObject.tag == "EnemyPlaya"|| collision.gameObject.tag == "EnemyCiudad"|| collision.gameObject.tag == "EnemyParque")
        {
            colision = false;
        }

    }

    IEnumerator FadeAudio(AudioClip changer)
    {
        while (myAudio.volume > 0)
        {
            myAudio.volume -= startvolume * Time.deltaTime;

            yield return null;
        }
        myAudio.Stop();
        myAudio.volume = startvolume;
        myAudio.clip = changer;
        myAudio.Play();

    }
}
