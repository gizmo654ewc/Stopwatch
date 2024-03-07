using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectShotScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float shotSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up.normalized * shotSpeed;
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
