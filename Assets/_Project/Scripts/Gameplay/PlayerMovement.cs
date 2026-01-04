using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 1;
    Rigidbody2D myrigidbody2D;

    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {

    }

    void OnArriba(InputValue value)
    {
        if (value.isPressed)
        {
            myrigidbody2D.velocity = new Vector2(0f, playerSpeed);
        }
        else
        {
            myrigidbody2D.velocity = new Vector2(0f, 0f);
        }
    }

    void OnAbajo(InputValue value)
    {
        if (value.isPressed)
        {
            myrigidbody2D.velocity = new Vector2(0f, -playerSpeed);
        }
        else
        {
            myrigidbody2D.velocity = new Vector2(0f, 0f);
        }
    }
}
