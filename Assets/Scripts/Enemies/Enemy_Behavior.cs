using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.U2D;

public class Enemy_Behavior : MonoBehaviour
{
    public GameObject route1;
    public GameObject route2;
    public GameObject route3;

    private GameObject emitter;
    Emitter_Basic emitScript;

    public GameObject sprite;

    public enum ShotChoice
    {
        Aimed,
        Around,
        Cone
    };

    public ShotChoice shotChoice;

    public float shotWait;
    public int shotsFired;
    public int coneShotNum;
    public float coneWide;

    private bool route1_complete = false;
    public bool shooting_complete = false;
    private bool stop_shooting = false;
    private float startTime;
    private float startTime2;
    private bool check = false;

    public float speed;
    public float durationEnter;
    public float durationLeave;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        emitter = transform.GetChild(1).gameObject;
        emitScript = emitter.GetComponent<Emitter_Basic>();
        transform.position = route1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        if (!route1_complete)
        {
            //lerp=smoothed, adding the vector makes the enemy activate sooner
            //transform.position = Vector2.Lerp(transform.position, route2.transform.position + new Vector3(0, -0.006f), step);

            //nonsmoothed
            //transform.position = Vector3.MoveTowards(transform.position, route2.transform.position, step);

            //smoothstep = aim to smooth just the beginning and end of movement
            float t = (Time.time - startTime) / durationEnter;
            transform.position = new Vector3(Mathf.SmoothStep(route1.transform.position.x, route2.transform.position.x, t), Mathf.SmoothStep(route1.transform.position.y, route2.transform.position.y, t), 0);

            if (transform.position.y == route2.transform.position.y)
            {
                route1_complete = true;
            }
        }
        if (route1_complete && !stop_shooting)
        {
            StartCoroutine(Shoot(shotWait, shotsFired));
            stop_shooting = true;
        }
        if (route1_complete && shooting_complete)
        {
            if (check == false)
            {
                startTime2 = Time.time;
                check = true;
            }
            float t2 = (Time.time - startTime2) / durationLeave;
            transform.position = new Vector3(Mathf.SmoothStep(route2.transform.position.x, route3.transform.position.x, t2), Mathf.SmoothStep(route2.transform.position.y, route3.transform.position.y, t2), 0);
        }
    }
    IEnumerator Shoot(float wait, int num)
    {
        for (int i = 0; i < num; i++)
        {
            if (shotChoice == ShotChoice.Aimed)
            {
                emitScript.S_Aimed();
            }
            else if (shotChoice == ShotChoice.Around)
            {
                emitScript.S_Around(coneWide);
            }
            else if (shotChoice == ShotChoice.Cone)
            {
                emitScript.S_AimedCone(coneWide, coneShotNum);
            }
            yield return new WaitForSeconds(wait);
        }
        yield return new WaitForSeconds(2f);
        shooting_complete = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerShot")
        {
            Debug.Log("e_hit");
            Destroy(col.gameObject);
            StartCoroutine(Flicker());
            //Destroy(this.transform.parent.gameObject);
        }
    }

    IEnumerator Flicker()
    {
        sprite.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.04f);
        sprite.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
