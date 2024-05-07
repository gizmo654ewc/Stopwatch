using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.U2D;
using UnityEngine.UI;

public class BS_Easy_Phase2 : MonoBehaviour
{
    //values
    public int health;
    public float shotWait;
    private float currWait;
    public float shotWait2;
    private float currWait2;

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
        currWait2 = 1f;
        eb1 = emitter1.GetComponent<Emitter_Basic>();
        eb2 = emitter2.GetComponent<Emitter_Basic>();
        eb3 = emitter3.GetComponent<Emitter_Basic>();
        eb4 = emitter4.GetComponent<Emitter_Basic>();

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
            currWait2 -= Time.deltaTime;
            if (currWait < 0)
            {
                currWait = shotWait;
                eb1.S_Static(0, 16, 360);
                eb2.S_Static(0, 16, 360);
            }
            if (currWait2 < 0) 
            {
                currWait2 = shotWait2;
                eb3.S_Aimed();
                eb4.S_Aimed();
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
