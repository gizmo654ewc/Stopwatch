using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_MoveD : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(0, -1, 0);
        move = move * Time.deltaTime * speed;
        transform.position = transform.position + move;
    }
}
