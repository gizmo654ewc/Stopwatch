using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBounce : MonoBehaviour
{
    Rigidbody2D rb;
    public int bounce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(rb.velocity.x, bounce));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
