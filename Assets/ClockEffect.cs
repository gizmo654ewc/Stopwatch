using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockEffect : MonoBehaviour
{
    public GameObject picture;
    SpriteRenderer sr;
    float a = 0.09f;

    float timeAlive = 0.5f;
    float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timeAlive;
        sr = picture.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (a > 0)
        {
            a -= 1f * Time.deltaTime;
        }
        sr.color = new Color(1f, 1f, 1f, a);
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) 
        {
            Destroy(this.gameObject);
        }
    }
}
