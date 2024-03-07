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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // for testing aimed
        if (Input.GetKeyDown(KeyCode.A))
        {
            Aimed();
        }
    }

    //Aimed() aims the shot at the player, if the player isn't dead (null)
    public void Aimed()
    {

        player = GameObject.Find("Player");
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
        player = GameObject.Find("Player");
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

    //destroys the bullets when offscreen
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
