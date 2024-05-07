using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearDisappear : MonoBehaviour
{
    SpriteRenderer sr;
    float a = 0f;

    float speed = 1f;

    bool appeared = false;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!appeared)
        {
            a += speed * Time.deltaTime;
        }
        else
        {
            a -= speed * Time.deltaTime;
        }
        if (a >= 1f)
        {
            appeared = true;
        }
        sr.color = new Color(1f, 1f, 1f, a);
        if (appeared && a <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
