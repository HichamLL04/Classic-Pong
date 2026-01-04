using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float velocidad = 5;
    Rigidbody2D myrigidbody2D;
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        myrigidbody2D.linearVelocity = new Vector2(velocidad, 2f);
    }

    void Update()
    {
        
    }
}
