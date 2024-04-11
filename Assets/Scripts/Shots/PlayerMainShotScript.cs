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
        Vector2 adjustedVec = Quaternion.Euler(0, 0, deg) * Vector2.up;
        transform.position = new Vector2(transform.position.x, transform.position.y) + (adjustedVec * shotSpeed) * Time.unscaledDeltaTime;
    }

    public void Shoot(float deg)
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 adjustedVec = Quaternion.Euler(0, 0, deg) * Vector2.up;
        rb.velocity = adjustedVec * shotSpeed;
        transform.rotation = transform.rotation * Quaternion.Euler(0, 0, deg);
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
