using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using static UnityEngine.GraphicsBuffer;

public class Enemy_Behavior : MonoBehaviour
{
    public enum MoveChoice
    {
        StopAndShoot,
        ShootWhileMove,
    };

    public MoveChoice moveChoice;


    public GameObject route1;
    public GameObject route2;
    public GameObject route3;

    public GameObject pointItem;
    public GameObject timeItem;
    public GameObject scoreItem;

    public GameObject explosion;

    private GameObject gm;
    GameManager gmscript;

    private GameObject emitter;
    Emitter_Basic emitScript;

    public GameObject sprite;

    public enum ShotChoice
    {
        Aimed,
        Around,
        Cone,
        Static,
        Spin,
        SpinReverse
    };

    public ShotChoice shotChoice;

    public int health;
    public float shotWait;
    public int shotsFired;
    public int coneShotNum;
    public float coneWide;
    public float staticDirection;
    public int spinDeg;
    public int spinSpeed;

    private float currwait;

    private bool route1_complete = false;
    public bool shooting_complete = false;
    private bool stop_shooting = false;
    private float startTime;
    private float startTime2;
    private bool check = false;

    public float speed;
    public float durationEnter;
    public float durationLeave;

    private GameObject scoreobj;
    PointCounter score;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager");
        gmscript = gm.GetComponent<GameManager>();
        scoreobj = GameObject.FindWithTag("ScoreOBJ");
        score = scoreobj.GetComponent<PointCounter>();
        currwait = 1;
        startTime = Time.time;
        emitter = transform.GetChild(1).gameObject;
        emitScript = emitter.GetComponent<Emitter_Basic>();
        transform.position = route1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        if (moveChoice == MoveChoice.ShootWhileMove)
        {
            if (currwait > 0)
            {
                currwait -= Time.deltaTime;
            }
            else
            {
                currwait = shotWait * shotsFired;
                StartCoroutine(Shoot(shotWait, shotsFired));
            }

            transform.position = Vector2.MoveTowards(transform.position, route2.transform.position, step);
            if (transform.position == route2.transform.position)
            {
                Destroy(this.transform.parent.gameObject);
            }
        }
        else if (moveChoice == MoveChoice.StopAndShoot)
        {
            if (!route1_complete)
            {
                float t = (Time.time - startTime) / durationEnter;
                transform.position = new Vector3(Mathf.SmoothStep(route1.transform.position.x, route2.transform.position.x, t), Mathf.SmoothStep(route1.transform.position.y, route2.transform.position.y, t), 0);

                if ((transform.position.x > route2.transform.position.x + 0.05 ^ transform.position.x > route2.transform.position.x - 0.05) && (transform.position.y > route2.transform.position.y + 0.05 ^ transform.position.y > route2.transform.position.y - 0.05)) 
                {
                    transform.position = route2.transform.position;
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
            else if (shotChoice == ShotChoice.Static)
            {
                emitScript.S_Static(staticDirection, coneShotNum, coneWide);
            }
            else if (shotChoice == ShotChoice.Spin)
            {
                StartCoroutine(Spin(spinDeg, spinSpeed));
            }
            else if (shotChoice == ShotChoice.SpinReverse)
            {
                if (i % 2 == 0) 
                {
                    StartCoroutine(Spin(spinDeg, spinSpeed));
                }
                else
                {
                    StartCoroutine(Spin(spinDeg, -spinSpeed));
                }
            }
            yield return new WaitForSeconds(wait);
        }
        yield return new WaitForSeconds(0.3f);
        shooting_complete = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerShot")
        {
            Destroy(col.gameObject);
            StartCoroutine(Flicker());
            health--;
            if (health == 0)
            {
                score.score += 100;
                if (gmscript.power < 72)
                {
                    Instantiate(pointItem, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(scoreItem, transform.position, Quaternion.identity);
                }
                Instantiate(timeItem, transform.position, Quaternion.identity);
                Destroy(this.transform.parent.gameObject);
                Instantiate(explosion, transform.position, Quaternion.identity);
            }
        }
    }

    IEnumerator Flicker()
    {
        sprite.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.04f);
        sprite.GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator Spin(int spinDeg, int spinSpeed)
    {
        for (int i = 0; Math.Abs(i) < spinDeg; i+=spinSpeed)
        {
            emitScript.S_Static(i, 1, 0);
            yield return new WaitForSeconds(0.02f);
        }
    }
}
