using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public GameObject shotPrefab;
    public float movementSpeed;
    public float autofireSpeed;
    private float autofireSpeed2;
    private float currentFire;
    private float currentSpeed;


    void Start()
    {
        currentSpeed = movementSpeed;
        currentFire = autofireSpeed; 
        autofireSpeed2 = autofireSpeed;
    }

    void Update()
    {
        if (currentFire > 0){
            currentFire -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)){
            currentSpeed = (movementSpeed*(float)0.55);
            autofireSpeed2 = autofireSpeed*(float).85;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift)){
            currentSpeed = movementSpeed;
            autofireSpeed2 = autofireSpeed;
        }

        if (Input.GetKey(KeyCode.Z)){
            if (currentFire <= 0){
                currentFire = autofireSpeed2;
                GameObject shot = Instantiate(shotPrefab, (transform.position + new Vector3(0, (float).5, 0)), Quaternion.identity);
            }
        }

        //get the Input from Horizontal axis
        float hInput = Input.GetAxisRaw("Horizontal");
        //get the Input from Vertical axis
        float vInput = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(hInput, vInput, 0);
        move = move.normalized * Time.deltaTime * currentSpeed;
        transform.position = transform.position + move;
    }
}