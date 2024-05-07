using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEffect : MonoBehaviour
{
    SpriteRenderer sr;
    public float a = 0;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (a > 0)
        {
            a -= speed * Time.unscaledDeltaTime;
        }
        sr.color = new Color(.47f, .13f, .5f, a);
    }
}
