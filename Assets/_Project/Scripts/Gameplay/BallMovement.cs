using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float velocidad = 5;
    [SerializeField] AudioClip gol;
    [SerializeField] AudioClip raqueta;

    [SerializeField] AudioClip pared;

    Rigidbody2D myrigidbody2D;
    CircleCollider2D mycircleCollider2D;
    AudioSource audioSource;
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mycircleCollider2D = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();
        myrigidbody2D.linearVelocity = new Vector2(velocidad, 2f);
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (mycircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Paredes")))
        {
           audioSource.PlayOneShot(pared);
        }else if (mycircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            audioSource.PlayOneShot(raqueta);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (mycircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Paredes")))
        {
           audioSource.PlayOneShot(gol);
        }
    }
}
