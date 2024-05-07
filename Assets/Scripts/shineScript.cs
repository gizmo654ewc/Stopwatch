using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shineScript : MonoBehaviour
{
    SpriteRenderer sr;
    private float a = 0;
    public float speed;

    public bool glow = false;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        sr.color = new Color(1f, 1f, 1f, a);
        if (glow)
        {
            if (a < .08f)
            {
                a += speed * Time.deltaTime;
            }
            sr.color = new Color(1f, 1f, 1f, a);
        }
        else
        {
            if (a > 0)
            {
                a -= speed * Time.deltaTime;
            }
        }
    }
}
