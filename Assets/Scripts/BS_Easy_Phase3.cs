using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.U2D;
using UnityEngine.UI;

public class BS_Easy_Phase3 : MonoBehaviour
{
    //values
    public int health;
    public float shotWait;
    public int low;
    public int max;
    private float currWait;
    private int prevRand = 0;
    private int currRand = 1;

    private float startWait = 2f;
    private float currStartWait;

    private bool attacking = false;

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
        healthImage.color = new Color(0f, 0f, 0f, 0f);
        hs.SetMaxHealth(health);

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
        currStartWait -= Time.deltaTime;
        if (currStartWait < 0)
        {
            attacking = true;
            healthImage.color = Color.red;
        }
        // behavior
        if (attacking)
        {
            currWait -= Time.deltaTime;
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerShot")
        {
            Destroy(col.gameObject);
            if (attacking)
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

    IEnumerator Flicker()
    {
        sprite.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.04f);
        sprite.GetComponent<SpriteRenderer>().color = Color.white;
    }
}