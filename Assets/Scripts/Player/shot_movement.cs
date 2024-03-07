using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot_movement : MonoBehaviour
{
    public float shotSpeed;
    private float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = shotSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(0, 1, 0);
        move = move * Time.deltaTime * currentSpeed;
        transform.position = transform.position + move;
    }
    void OnBecameInvisible(){
        Destroy(this.gameObject);
    }
}
