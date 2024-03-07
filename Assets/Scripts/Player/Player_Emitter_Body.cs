using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player_Emitter_Body : MonoBehaviour
{
    public GameObject shotPrefab;
    PlayerMainShotScript shotscript;
    private GameObject shot;
    public float shotSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            p1_shot();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            p2_shot();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            p3_shot();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            p4_shot();
        }

    }

    //shots, increasing in amount and cone shot in as power increases
    void p1_shot()
    {
        shot = Instantiate(shotPrefab, (transform.position), Quaternion.identity);
        shotscript = shot.GetComponent<PlayerMainShotScript>();
        shotscript.shotSpeed = shotSpeed;
        shotscript.Shoot(0);
    }
    void p2_shot()
    {
        float range = 8f;
        int num = 2;
        for (int i = 0; i < num; i++)
        {
            shot = Instantiate(shotPrefab, (transform.position), Quaternion.identity);
            shotscript = shot.GetComponent<PlayerMainShotScript>();
            shotscript.shotSpeed = shotSpeed;
            shotscript.Shoot((range / (num - 1)) * i - (range / 2));
        }
    }
    void p3_shot()
    {
        float range = 16f;
        int num = 3;
        for (int i = 0; i < num; i++)
        {
            shot = Instantiate(shotPrefab, (transform.position), Quaternion.identity);
            shotscript = shot.GetComponent<PlayerMainShotScript>();
            shotscript.shotSpeed = shotSpeed;
            shotscript.Shoot((range / (num - 1)) * i - (range / 2));
        }
    }
    void p4_shot()
    {
        float range = 29f;
        int num = 5;
        for (int i = 0; i < num; i++)
        {
            shot = Instantiate(shotPrefab, (transform.position), Quaternion.identity);
            shotscript = shot.GetComponent<PlayerMainShotScript>();
            shotscript.shotSpeed = shotSpeed;
            shotscript.Shoot((range / (num - 1)) * i - (range / 2));
        }
    }

}
