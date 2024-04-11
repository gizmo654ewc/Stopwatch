using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEmitterEffect : MonoBehaviour
{
    public GameObject center;
    public GameObject left;
    public GameObject right;

    public GameObject shotPrefab;
    public GameObject slowedshotPrefab;
    EffectShotScript shotscript;
    private GameObject shot;
    private GameObject currentShot;
    public float shotSpeed;

    public bool rightside;

    public GameObject unPosL;
    public GameObject focPosL;
    public GameObject unPosR;
    public GameObject focPosR;

    private GameObject timeBomb;
    TimeBombHandler timeBombHandler;

    // Start is called before the first frame update
    void Start()
    {
        currentShot = shotPrefab;
        timeBomb = GameObject.FindWithTag("TimeBombHandler");
        timeBombHandler = timeBomb.GetComponent<TimeBombHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBombHandler.timeSlow)
        {
            currentShot = slowedshotPrefab;
        }
        else
        {
            currentShot = shotPrefab;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (rightside)
            {
                transform.position = Vector2.MoveTowards(transform.position, focPosR.transform.position, Time.unscaledDeltaTime * 10);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, focPosL.transform.position, Time.unscaledDeltaTime*10);
            }
        }
        else
        {
            if (rightside)
            {
                transform.position = Vector2.MoveTowards(transform.position, unPosR.transform.position, Time.unscaledDeltaTime * 10);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, unPosL.transform.position, Time.unscaledDeltaTime*10);
            }
        }
    }

    //shot power levels
    public void p1_shot()
    {
        shot = Instantiate(currentShot, (center.transform.position + new Vector3(0, 0.5f, 0)), Quaternion.identity);
    }
    public void p2_shot()
    {
        shot = Instantiate(currentShot, (center.transform.position + new Vector3(0, 0.5f, 0)), Quaternion.identity);
        if (rightside)
        {
            shot = Instantiate(currentShot, (right.transform.position + new Vector3(0, 0.5f, 0)), Quaternion.identity);
        }
        else
        {
            shot = Instantiate(currentShot, (left.transform.position + new Vector3(0, 0.5f, 0)), Quaternion.identity);
        }
    }
    public void p3_shot()
    {
        shot = Instantiate(currentShot, (center.transform.position + new Vector3(0, 0.5f, 0)), Quaternion.identity);
        shot = Instantiate(currentShot, (left.transform.position + new Vector3(0, 0.5f, 0)), Quaternion.identity);
        shot = Instantiate(currentShot, (right.transform.position + new Vector3(0, 0.5f, 0)), Quaternion.identity);
    }
}
