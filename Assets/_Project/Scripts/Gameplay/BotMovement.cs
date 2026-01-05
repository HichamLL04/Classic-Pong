using UnityEngine;

public class BotMovement : MonoBehaviour
{

    [SerializeField] GameObject pelota;
    [SerializeField] float playerSpeed = 5;

    Rigidbody2D myrigidbody2D;
    public bool botPlaying = true;
    void Start()
    {
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
            SeguirPelota(direccion);
        }
    }

    void SeguirPelota(float direccion)
    {
        myrigidbody2D.linearVelocity = new Vector2(0f, direccion * playerSpeed);

    }
}
