using UnityEngine;

public class BotMovement : MonoBehaviour
{

    [SerializeField] GameObject pelota;
    [SerializeField] float playerSpeed = 4;
    [SerializeField] float margenError = 1.5f;

    Rigidbody2D myrigidbody2D;
    public bool botPlaying;
    void Start()
    {
        botPlaying = PlayerPrefs.GetInt("botPlaying", 0) == 1;
        if (botPlaying)
        {
            PlayerMovement playerMovement = GetComponent<PlayerMovement>();
            playerMovement.enabled = false;
            myrigidbody2D = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        if (botPlaying)
        {
            float posicionYPelota = pelota.transform.position.y;
            float posicionYPala = myrigidbody2D.transform.position.y;
            float direccion = posicionYPelota - posicionYPala;
            if (Mathf.Abs(direccion) > margenError)
            {
                SeguirPelota(direccion);
            }
            else
            {
                myrigidbody2D.linearVelocity = Vector2.zero;
            }
        }
    }

    void SeguirPelota(float direccion)
    {
        myrigidbody2D.linearVelocity = new Vector2(0f, direccion * playerSpeed);

    }
}
