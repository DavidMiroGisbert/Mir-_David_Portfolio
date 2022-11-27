using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    
  
    public Slider barraVolumen;
    public Slider barraSensibilidad;
    public AudioSource Musica;

    // Modificar volumen y sensibilidad con sliders
    void Update()
    {
        CanonMovement.Sensibilidad_0_1 = barraSensibilidad.value;
        Musica.volume = barraVolumen.value;

    }

}
