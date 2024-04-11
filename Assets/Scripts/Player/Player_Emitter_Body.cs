using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player_Emitter_Body : MonoBehaviour
{
    public GameObject shotPrefab;
    public GameObject slowedshotPrefab;
    PlayerMainShotScript shotscript;
    private GameObject shot;
    private GameObject currentShot;

    private GameObject timeBomb;
    TimeBombHandler timeBombHandler;

    // Start is called before the first frame update
    void Start()
    {
        currentShot = shotPrefab;
        timeBomb = GameObject.FindWithTag("TimeBombHandler");
        timeBombHandler = timeBomb.GetComponent<TimeBombHandler>();
    }

    private void Update()
    {
        if (timeBombHandler.timeSlow)
        {
            currentShot = slowedshotPrefab;
        }
        else
        {
            currentShot = shotPrefab;
        }
    }

    //shots, increasing in amount and cone shot in as power increases
    public void p1_shot()
    {
        shot = Instantiate(currentShot, transform.position, Quaternion.identity);
        shotscript = shot.GetComponent<PlayerMainShotScript>();
        shotscript.deg = 0;
    }
    public void p2_shot()
    {
        float range = 8f;
        int num = 2;
        for (int i = 0; i < num; i++)
        {
            shot = Instantiate(currentShot, transform.position, Quaternion.identity);
            shotscript = shot.GetComponent<PlayerMainShotScript>();
            shotscript.deg = (range / (num - 1)) * i - (range / 2);
        }
    }
    public void p3_shot()
    {
        float range = 16f;
        int num = 3;
        for (int i = 0; i < num; i++)
        {
            shot = Instantiate(currentShot, transform.position, Quaternion.identity);
            shotscript = shot.GetComponent<PlayerMainShotScript>();
            shotscript.deg = (range / (num - 1)) * i - (range / 2);
        }
    }
    public void p4_shot()
    {
        float range = 29f;
        int num = 5;
        for (int i = 0; i < num; i++)
        {
            shot = Instantiate(currentShot, transform.position, Quaternion.identity);
            shotscript = shot.GetComponent<PlayerMainShotScript>();
            shotscript.deg = (range / (num - 1)) * i - (range / 2);
        }
    }

}
