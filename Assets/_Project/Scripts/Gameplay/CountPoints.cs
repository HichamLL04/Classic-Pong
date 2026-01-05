using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CountPoints : MonoBehaviour
{
    [SerializeField] Rigidbody2D pelota;
    [SerializeField] TextMeshProUGUI canvasAzul;
    [SerializeField] TextMeshProUGUI canvasNaranja;
    [SerializeField] GameObject juego;
    [SerializeField] GameObject subMenu;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    [SerializeField] UnityEngine.UI.Image panel;



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
            if (scoreAzul < 4)
            {
                scoreAzul += 1;
                canvasAzul.text = scoreAzul.ToString();
            }
            else
            {
                Win("Azul");
            }

        }
        else if (goleador.Equals("Naranja"))
        {
            if (scoreNaranja < 4)
            {
                scoreNaranja += 1;
                canvasNaranja.text = scoreNaranja.ToString();
            }
            else
            {
                Win("Naranja");
            }

        }
    }

    void Win(String ganador)
    {
        juego.SetActive(false);
        subMenu.SetActive(true);
        if (ganador.Equals("Azul"))
        {
            panel.color = new Color(0.035f, 0.612f, 0.902f, 1f);
            textMeshProUGUI.text = "BLUE PLAYER WINS";
        }
        else
        {
            panel.color = new Color(0.902f, 0.537f, 0.039f, 1f);
            textMeshProUGUI.text = "ORANGE PLAYER WINS";
        }
    }
}
