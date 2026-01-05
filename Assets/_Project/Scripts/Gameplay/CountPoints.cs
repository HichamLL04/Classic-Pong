using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CountPoints : MonoBehaviour
{
    [SerializeField] GameObject pelota;
     [SerializeField] TextMeshProUGUI canvasAzul;
    [SerializeField] TextMeshProUGUI canvasNaranja;


    float scoreAzul = 0;
    float scoreNaranja = 0;


    void Start()
    {
        
    }

    void Update()
    {

    }

    public void SumarPuntuacion(String goleador)
    {
        if (goleador.Equals("Azul"))
        {
            scoreAzul += 1;
            canvasAzul.text = scoreAzul.ToString();
        }
        else if (goleador.Equals("Naranja"))
        {
            scoreNaranja += 1;
            canvasNaranja.text = scoreNaranja.ToString(); 
        }
    }
}
