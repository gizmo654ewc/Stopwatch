using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ES_Basic : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float speed;
    //vectors for determining aim
    private Vector2 charPos;
    private Vector2 initPos;
    private Vector2 fromTo;
    private Vector2 shotVel;
    private Vector2 adjustedVec;
    private Quaternion rotate;

    //for circledestroy
    private GameObject tbhObj;
    TimeBombHandler tbh;
    public bool inCricle = false;

    //audio
    [SerializeField] private AudioSource shotSound;

    // Start is called before the first frame update
    void Start()
    {
        shotSound.Play();
        tbhObj = GameObject.FindWithTag("TimeBombHandler");
        tbh = tbhObj.GetComponent<TimeBombHandler>();

        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Destroy(gameObject);
        }

        StartCoroutine(WaitAndDelete());
    }

    // Update is called once per frame
    void Update()
    {
        if (tbh.circleDelete)
        {
            if (inCricle)
            {
                Destroy(this.gameObject);
            }
        }
    }

    //Aimed() aims the shot at the player, if the player isn't dead (null)
    public void Aimed()
    {

        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            rb = GetComponent<Rigidbody2D>();
            charPos = player.transform.position;
            initPos = transform.position;
            fromTo = charPos - initPos;
            fromTo.Normalize();
            shotVel = fromTo * speed;
            rb.velocity = shotVel;
        }
    }

    //AimedOffset() aims the shot at the player, then adjusts the angle off by the inputted degrees
    public void AimedOffset(float deg)
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            rb = GetComponent<Rigidbody2D>();
            Vector2 charPos = player.transform.position;
            Vector2 initPos = transform.position;
            Vector2 fromTo = charPos - initPos;
            fromTo.Normalize();
            Quaternion rotate = Quaternion.Euler(0, 0, deg);
            adjustedVec = rotate * fromTo;
            shotVel = adjustedVec * speed;
            rb.velocity = shotVel;
        }
    }

    //static shots, not aimed at player, specified by degrees from the down vector
    public void Static(float deg)
    {
        rb = GetComponent<Rigidbody2D>();
        Quaternion rotate = Quaternion.Euler(0, 0, deg);
        adjustedVec = rotate * Vector2.down;
        shotVel = adjustedVec * speed;
        rb.velocity = shotVel;
    }

    //destroys the bullets when offscreen
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    IEnumerator WaitAndDelete()
    {
        yield return new WaitForSeconds(1f);
        if (rb.velocity == Vector2.zero)
        {
            Destroy(this.gameObject);
        }
    }
}
