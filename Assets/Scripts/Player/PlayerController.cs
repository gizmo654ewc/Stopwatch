using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gamemanager;
    public float movementSpeed;
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
        currentSpeed = movementSpeed;

        //spawn invulnerability
        StartCoroutine(InvincibleFor());
        StartCoroutine(Flicker());
    }

    void Update()
    {
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
