using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    private float currentSpeed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = movementSpeed;
    }

    void Update()
    {
        //focus speed
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentSpeed = (movementSpeed * (float)0.55);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeed = movementSpeed;
        }

        //get the Input from Horizontal axis
        float hInput = Input.GetAxisRaw("Horizontal");
        //get the Input from Vertical axis
        float vInput = Input.GetAxisRaw("Vertical");

        //movement
        Vector3 move = new Vector3(hInput, vInput, 0);
        move = move.normalized * currentSpeed;
        rb.velocity = move;
    }
}
