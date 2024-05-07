using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.U2D;
using UnityEngine.UI;

public class BS_Easy_Phase1 : MonoBehaviour
{
    //values
    public int health;
    public float shotWait;
    public int low;
    public int max;
    private float currWait;
    private int prevRand = 0;
    private int currRand = 1;

    private float startWait = 1.5f;
    private float currStartWait;

    //routing
    private bool route1 = false;
    [SerializeField] private GameObject waypoint1;

    private bool announceBoss = false;

    private bool defeated = false;

    //health
    private GameObject healthBar;
    private Graphic healthImage;

    private GameObject BossCanvas;
    HealthSlider hs;

    //sprite/image
    public GameObject sprite;

    //items
    public GameObject timeItem;
    public GameObject powerItem;
    public GameObject explosions;

    //score
    private GameObject scoreobj;
    PointCounter score;

    //announce
    [SerializeField] private GameObject announcement;

    //emitters
    [SerializeField] private GameObject emitter1;
    Emitter_Basic eb1;
    [SerializeField] private GameObject emitter2;
    Emitter_Basic eb2;
    [SerializeField] private GameObject emitter3;
    Emitter_Basic eb3;
    [SerializeField] private GameObject emitter4;
    Emitter_Basic eb4;
    [SerializeField] private GameObject emitter5;
    Emitter_Basic eb5;
    [SerializeField] private GameObject emitter6;
    Emitter_Basic eb6;

    //next phase
    [SerializeField] private GameObject nextPhase;


    // Start is called before the first frame update
    void Start()
    {
        //score
        scoreobj = GameObject.FindWithTag("ScoreOBJ");
        score = scoreobj.GetComponent<PointCounter>();

        //health stuff
        healthBar = GameObject.Find("HealthImage");
        healthImage = healthBar.GetComponent<Graphic>();

        BossCanvas = GameObject.FindWithTag("Health");
        hs = BossCanvas.GetComponent<HealthSlider>();

        //shot stuff
        currWait = shotWait;
        eb1 = emitter1.GetComponent<Emitter_Basic>();
        eb2 = emitter2.GetComponent<Emitter_Basic>();
        eb3 = emitter3.GetComponent<Emitter_Basic>();
        eb4 = emitter4.GetComponent<Emitter_Basic>();
        eb5 = emitter5.GetComponent<Emitter_Basic>();
        eb6 = emitter6.GetComponent<Emitter_Basic>();

        currStartWait = startWait;
    }

    // Update is called once per frame
    void Update()
    {
        //behavior
        if (!route1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint1.transform.position, Time.deltaTime * 1f);
        }
        else if (!announceBoss)
        {
            Instantiate(announcement, new Vector3(0f, 3f, 0f), Quaternion.identity);
            announceBoss = true;
            healthImage.color = Color.red;
            Debug.Log("set color");
            hs.SetMaxHealth(health);
        }
        else if (!defeated) 
        {
            currStartWait -= Time.deltaTime;
            currWait -= Time.deltaTime;
            if (currStartWait < 0)
            {
                if (currWait < 0)
                {
                    currWait = shotWait;
                    currRand = Random.Range(1, 7);
                    while (prevRand == currRand)
                    {
                        currRand = Random.Range(1, 7);
                    }
                    prevRand = currRand;
                    if (currRand == 1)
                    {
                        eb1.S_Static(Random.Range(low / 2, max), 1, 0);
                    }
                    else if (currRand == 2)
                    {
                        eb2.S_Static(Random.Range(low / 1.5f, max), 1, 0);
                    }
                    else if (currRand == 3)
                    {
                        eb3.S_Static(Random.Range(low, max), 1, 0);
                    }
                    else if (currRand == 4)
                    {
                        eb4.S_Static(Random.Range(low, max), 1, 0);
                    }
                    else if (currRand == 5)
                    {
                        eb5.S_Static(Random.Range(low, max / 1.5f), 1, 0);
                    }
                    else if (currRand == 6)
                    {
                        eb6.S_Static(Random.Range(low, max / 2), 1, 0);
                    }
                }
           
            }
        }

        //end route 1
        if (transform.position.y >= waypoint1.transform.position.y-0.2 && transform.position.y <= waypoint1.transform.position.y + 0.2)
        {
            route1 = true;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerShot")
        {
            Destroy(col.gameObject);
            if (announceBoss)
            {
                if (currStartWait < 0)
                {
                    StartCoroutine(Flicker());
                    health--;
                    hs.SetHealth(health);
                    if (health == 0)
                    {
                        Destroy(this.gameObject);
                        Instantiate(explosions, transform.position, Quaternion.identity);
                        Instantiate(powerItem, transform.position, Quaternion.identity);
                        Instantiate(timeItem, transform.position, Quaternion.identity);
                        score.score += 10000;
                        Instantiate(nextPhase, transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }
    IEnumerator Flicker()
    {
        sprite.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.04f);
        sprite.GetComponent<SpriteRenderer>().color = Color.white;
    }
}