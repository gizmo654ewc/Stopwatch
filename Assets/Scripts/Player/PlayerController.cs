using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject centerEmitter;
    public GameObject leftEmitter;
    public GameObject rightEmitter;
    Player_Emitter_Body centerE;
    PlayerEmitterEffect leftE;
    PlayerEmitterEffect rightE;

    GameManager gamemanager;
    public int power;
    public float movementSpeed;
    public float autofireSpeed;
    private float currentFire;
    private float currentSpeed;
    [SerializeField]
    private float invincibleTime;
    private bool invincible = true;
    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        centerE = centerEmitter.GetComponent<Player_Emitter_Body>();
        leftE = leftEmitter.GetComponent<PlayerEmitterEffect>();
        rightE = rightEmitter.GetComponent<PlayerEmitterEffect>();
        currentFire = autofireSpeed;
        currentSpeed = movementSpeed;

        //spawn invulnerability
        StartCoroutine(InvincibleFor());
        StartCoroutine(Flicker());
    }

    void Update()
    {
        if (currentFire > 0)
        {
            currentFire -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            if (currentFire <= 0)
            {
                currentFire = autofireSpeed;
                if (power <= 10)
                {
                    centerE.p1_shot();
                }
                else if (power <= 20)
                {
                    centerE.p1_shot();
                    leftE.p1_shot();
                    rightE.p1_shot();
                }
                else if (power <= 30)
                {
                    centerE.p2_shot();
                    leftE.p1_shot();
                    rightE.p1_shot();
                }
                else if (power <= 40)
                {
                    centerE.p2_shot();
                    leftE.p2_shot();
                    rightE.p2_shot();
                }
                else if (power <= 50)
                {
                    centerE.p3_shot();
                    leftE.p2_shot();
                    rightE.p2_shot();
                }
                else if (power <= 60)
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

        //movement
        Vector3 move = new Vector3(hInput, vInput, 0);
        move = move.normalized * currentSpeed;
        rb.velocity = move;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyShot")
        {
            Destroy(col.gameObject);
            if (!invincible)
            {
                Destroy(this.gameObject);
                gamemanager.lifedown();
            }
        }
        else if (col.tag == "PowerItem")
        {
            Destroy(col.gameObject);
            power += 1;
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
}
