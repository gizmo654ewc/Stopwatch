using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainShotScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float shotSpeed;
    public float deg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Shoot(deg);
        }
    }

    public void Shoot(float deg)
    {
        rb = GetComponent<Rigidbody2D>();
        Quaternion rotate = Quaternion.Euler(0, 0, deg);
        Vector2 adjustedVec = rotate * Vector2.up;
        adjustedVec.Normalize();
        rb.velocity = adjustedVec * shotSpeed;
        transform.rotation = transform.rotation * rotate;
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
