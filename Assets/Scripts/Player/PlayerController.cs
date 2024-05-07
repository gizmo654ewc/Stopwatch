using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //datastorage
    private GameObject dataStorage;
    private DataStorage ds;
    private bool stopwatched = false;

    //audio
    [SerializeField] AudioSource shootSource;
    [SerializeField] AudioSource bombSource;


    private GameObject pressX;
    private SpriteRenderer pressXsR;

    public Animator animator;

    private GameObject screenShine;
    TimeEffect te;

    public GameObject centerEmitter;
    public GameObject leftEmitter;
    public GameObject rightEmitter;
    Player_Emitter_Body centerE;
    PlayerEmitterEffect leftE;
    PlayerEmitterEffect rightE;

    GameManager gamemanager;
    public int power;
    public int time;
    public float movementSpeed;
    public float autofireSpeed;
    private float currentFire;
    private float currentSpeed;
    [SerializeField]
    private float invincibleTime;
    private bool invincible = true;

    Rigidbody2D rb;
    SpriteRenderer sr;

    private GameObject timeBomb;
    TimeBombHandler timeBombHandler;

    private GameObject scoreobj;
    PointCounter score;

    public int timeMax = 30;
    private bool timeBlink = false;

    public GameObject clockEffect;
    public GameObject brokenClockEffect;
    public GameObject shine;
    private shineScript ss;

    void Start()
    {
        //datas
        dataStorage = GameObject.FindWithTag("DataStorage");
        ds = dataStorage.GetComponent<DataStorage>();
        stopwatched = ds.stopwatchUsed;

        pressX = GameObject.Find("PressX");
        pressXsR = pressX.GetComponent<SpriteRenderer>();

        //getting components
        scoreobj = GameObject.FindWithTag("ScoreOBJ");
        score = scoreobj.GetComponent<PointCounter>();
        timeBomb = GameObject.FindWithTag("TimeBombHandler");
        timeBombHandler = timeBomb.GetComponent<TimeBombHandler>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        centerE = centerEmitter.GetComponent<Player_Emitter_Body>();
        leftE = leftEmitter.GetComponent<PlayerEmitterEffect>();
        rightE = rightEmitter.GetComponent<PlayerEmitterEffect>();
        ss = shine.GetComponent<shineScript>();
        screenShine = GameObject.FindWithTag("ScreenShine");
        te = screenShine.GetComponent<TimeEffect>();

        //fire speed stuff
        currentFire = autofireSpeed;
        currentSpeed = movementSpeed;

        //spawn invulnerability
        StartCoroutine(InvincibleFor());
        StartCoroutine(Flicker());
    }

    void Update()
    {
        if (stopwatched)
        {

        }
        if (time >= timeMax)
        {
            if (!timeBlink)
            {
                StartCoroutine(FlickerPurple());
                timeBlink = true;
                ss.glow = true;
            }
            time = timeMax;
            if (!stopwatched)
            {
                pressXsR.color = Color.white;
            }
        }
        else if (time < 0)
        {
            time = 0;
        }

        if (currentFire > 0)
        {
            currentFire -= Time.unscaledDeltaTime;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (time >= timeMax)
            {
                time = 0;
                timeBlink = false;
                ss.glow = false;
                te.a = .5f;
                Instantiate(clockEffect, transform.position, Quaternion.identity);
                StartCoroutine(timeBombHandler.StopWatch());
                bombSource.Play();
                if (!stopwatched)
                {
                    pressXsR.color = new Color(0f, 0f, 0f, 0f);
                    stopwatched = true;
                    ds.stopwatchUsed = true;
                }
            }
        }

        if (Input.GetKey(KeyCode.Z))
        {
            if (currentFire <= 0)
            {
                shootSource.Play();
                currentFire = autofireSpeed;
                if (power <= 11)
                {
                    centerE.p1_shot();
                }
                else if (power <= 23)
                {
                    centerE.p1_shot();
                    leftE.p1_shot();
                    rightE.p1_shot();
                }
                else if (power <= 35)
                {
                    centerE.p2_shot();
                    leftE.p1_shot();
                    rightE.p1_shot();
                }
                else if (power <= 47)
                {
                    centerE.p2_shot();
                    leftE.p2_shot();
                    rightE.p2_shot();
                }
                else if (power <= 59)
                {
                    centerE.p3_shot();
                    leftE.p2_shot();
                    rightE.p2_shot();
                }
                else if (power <= 71)
                {
                    centerE.p3_shot();
                    leftE.p3_shot();
                    rightE.p3_shot();
                }
                else
                {
                    centerE.p4_shot();
                    leftE.p3_shot();
                    rightE.p3_shot();
                }
            }
        }
        //focus speed

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentSpeed = (movementSpeed * (float)0.55);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeed = movementSpeed;
        }

        //get the Input from Horizontal axis
        float hInput = Input.GetAxisRaw("Horizontal");
        //get the Input from Vertical axis
        float vInput = Input.GetAxisRaw("Vertical");

        //animator
        animator.SetFloat("Speed", Mathf.Abs(hInput));
        if (hInput < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        //movement
        Vector3 move = new Vector3(hInput, vInput, 0);
        if (timeBombHandler.timeSlow)
        {
            move = move.normalized * currentSpeed * 3f;
        }
        else
        {
            move = move.normalized * currentSpeed;
        }
        rb.velocity = move;

        //power management
        if (power < 0)
        {
            power = 0;
        }
        else if (power > 72)
        {
            power = 72;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyShot")
        {
            Destroy(col.gameObject);
            if (!invincible)
            {
                if (time == timeMax)
                {
                    timeMax += 20;
                    time = 0;
                    timeBlink = false;
                    ss.glow = false;
                    te.a = .5f;
                    bombSource.Play();
                    Instantiate(brokenClockEffect, transform.position, Quaternion.identity);
                    StartCoroutine(timeBombHandler.StopWatch());
                    pressXsR.color = new Color(0f, 0f, 0f, 0f);
                    stopwatched = true;
                    ds.stopwatchUsed = true;
                }
                else
                {
                    Destroy(this.gameObject);
                    gamemanager.lifedown();
                }
            }
        }
        else if (col.tag == "PowerItem")
        {
            Destroy(col.gameObject);
            power += 1;
        }
        else if (col.tag == "PowerItemBig")
        {
            Destroy(col.gameObject);
            power += 5;
        }
        else if (col.tag == "TimeItem")
        {
            Destroy(col.gameObject);
            time += 1;
        }
        else if (col.tag == "TimeItemBig")
        {
            Destroy(col.gameObject);
            time += 30;
        }
        else if (col.tag == "ScoreItem")
        {
            Destroy(col.gameObject);
            if (timeBombHandler.timeSlow)
            {
                score.score += 1000;
            }
            else
            {
                score.score += 500;
            }
        }
    }

    //set invincibility
    IEnumerator InvincibleFor()
    {
        yield return new WaitForSeconds(invincibleTime);
        invincible = false;
    }

    //flicker the sprite
    IEnumerator Flicker()
    {
        Color normal = sr.color;
        float time = invincibleTime/.08f;
        for (float i = 0; i < invincibleTime; i = i+.1f)
        {
            sr.color = Color.clear;
            yield return new WaitForSeconds(.04f);
            sr.color = normal;
            yield return new WaitForSeconds(.04f);
        }
    }
    IEnumerator FlickerPurple()
    {
        Color normal = sr.color;
        Color current = Color.magenta;
        float time = .9f;
        for (float i = 0; i < time; i = i + .1f)
        {
            sr.color = Color.magenta;
            yield return new WaitForSeconds(.06f);
            sr.color = normal;
            yield return new WaitForSeconds(.06f);
        }
    }
}
