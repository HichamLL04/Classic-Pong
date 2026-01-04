using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 1;
    Rigidbody2D myrigidbody2D;

    bool arribaPresionado = false;
    bool abajoPresionado = false;

    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

    }
    void FixedUpdate()
    {
        float direccion = 0f;

        if (arribaPresionado) direccion += 1f;
        if (abajoPresionado) direccion -= 1f;

        myrigidbody2D.velocity = new Vector2(0f, direccion * playerSpeed);
    }

    void OnArriba(InputValue value)
    {
        if (value.isPressed)
        {
            arribaPresionado = true;
        }
        else
        {
            arribaPresionado = false;
        }
    }

    void OnAbajo(InputValue value)
    {
        if (value.isPressed)
        {
            abajoPresionado = true;
        }
        else
        {
            abajoPresionado = false;
        }
    }
}
