using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.U2D;
using UnityEngine.UI;

public class BS_Easy_Phase4 : MonoBehaviour
{
    //values
    public int health;
    public float shotWait;
    private float currWait;

    private float startWait = 2f;
    private float currStartWait;

    private bool attacking = false;

    private bool offset = false;

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
                if (!offset)
                {
                    StartCoroutine(Spin(eb1, 360, -15));
                    StartCoroutine(Spin(eb2, 360, 15));
                    offset = !offset;
                }
                else
                {
                    StartCoroutine(Spin(eb1, 360, -25));
                    StartCoroutine(Spin(eb2, 360, 25));
                    offset = !offset;
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

    IEnumerator Spin(Emitter_Basic eb, int spinDeg, int spinSpeed)
    {
        for (int i = 0; Mathf.Abs(i) < spinDeg; i += spinSpeed)
        {
            eb.S_AimedOffset(i);
            yield return new WaitForSeconds(0.02f);
        }
    }
}