using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float velocidad = 10;
    [SerializeField] AudioClip gol;
    [SerializeField] AudioClip raqueta;

    [SerializeField] AudioClip pared;
    [SerializeField] float incrementoVelocidad = 0.5f;
    [SerializeField] float velocidadMaxima = 30f;

    Rigidbody2D myrigidbody2D;
    CircleCollider2D mycircleCollider2D;
    AudioSource audioSource;

    Vector2 lastDireccion;

    float velocidadInicial;
    void Start()
    {
        velocidadInicial = velocidad;
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mycircleCollider2D = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();
        StartGame();
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (mycircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Paredes")))
        {
            audioSource.PlayOneShot(pared);
        }
        else if (mycircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            audioSource.PlayOneShot(raqueta);
        }
        if (velocidad <= velocidadMaxima)
        {
            velocidad += incrementoVelocidad;
        }

        Vector2 direccion = myrigidbody2D.linearVelocity.normalized;
        myrigidbody2D.linearVelocity = direccion * velocidad;
        Debug.Log(velocidad);


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Azul"))
        {
            audioSource.PlayOneShot(gol);
            RestartGame(Vector2.right);
        }
        else if (collision.CompareTag("Naranja"))
        {
            audioSource.PlayOneShot(gol);
            RestartGame(Vector2.left);
        }
    }

    void StartGame()
    {
        float inclinacion = Random.Range(-0.4f, 0.4f);
        Vector2 direcion = Random.value < 0.5f ? Vector2.left : Vector2.right;
        direcion = new Vector2(direcion.x, inclinacion).normalized;
        myrigidbody2D.linearVelocity = direcion * velocidad;
    }


    void RestartGame(Vector2 direccion)
    {
        velocidad = velocidadInicial;
        myrigidbody2D.linearVelocity = Vector2.zero;
        transform.position = Vector3.zero;


        lastDireccion = direccion;
        Invoke(nameof(MoveBall), 1f);
    }

    void MoveBall()
    {
        Vector2 dir = new Vector2(-lastDireccion.x, Random.Range(-0.4f, 0.4f)).normalized;
        myrigidbody2D.linearVelocity = dir * velocidad;
    }
}
