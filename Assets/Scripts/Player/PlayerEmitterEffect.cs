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
    EffectShotScript shotscript;
    private GameObject shot;
    public float shotSpeed;

    public bool rightside;

    public GameObject unPosL;
    public GameObject focPosL;
    public GameObject unPosR;
    public GameObject focPosR;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            p1_shot();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            p2_shot();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            p3_shot();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (rightside)
            {
                transform.position = Vector2.MoveTowards(transform.position, focPosR.transform.position, Time.deltaTime * 10);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, focPosL.transform.position, Time.deltaTime*10);
            }
        }
        else
        {
            if (rightside)
            {
                transform.position = Vector2.MoveTowards(transform.position, unPosR.transform.position, Time.deltaTime * 10);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, unPosL.transform.position, Time.deltaTime*10);
            }
        }
    }

    //shot power levels
    public void p1_shot()
    {
        shot = Instantiate(shotPrefab, (center.transform.position + new Vector3(0, 0.5f, 0)), Quaternion.identity);
        shotscript = shot.GetComponent<EffectShotScript>();
        shotscript.shotSpeed = shotSpeed;
        shotscript.Shoot();
    }
    public void p2_shot()
    {
        shot = Instantiate(shotPrefab, (center.transform.position + new Vector3(0, 0.5f, 0)), Quaternion.identity);
        shotscript = shot.GetComponent<EffectShotScript>();
        shotscript.shotSpeed = shotSpeed;
        shotscript.Shoot();
        if (rightside)
        {
            shot = Instantiate(shotPrefab, (right.transform.position + new Vector3(0, 0.5f, 0)), Quaternion.identity);
            shotscript = shot.GetComponent<EffectShotScript>();
            shotscript.shotSpeed = shotSpeed;
            shotscript.Shoot();
        }
        else
        {
            shot = Instantiate(shotPrefab, (left.transform.position + new Vector3(0, 0.5f, 0)), Quaternion.identity);
            shotscript = shot.GetComponent<EffectShotScript>();
            shotscript.shotSpeed = shotSpeed;
            shotscript.Shoot();
        }
    }
    public void p3_shot()
    {
        shot = Instantiate(shotPrefab, (center.transform.position + new Vector3(0, 0.5f, 0)), Quaternion.identity);
        shotscript = shot.GetComponent<EffectShotScript>();
        shotscript.shotSpeed = shotSpeed;
        shotscript.Shoot();
        shot = Instantiate(shotPrefab, (left.transform.position + new Vector3(0, 0.5f, 0)), Quaternion.identity);
        shotscript = shot.GetComponent<EffectShotScript>();
        shotscript.shotSpeed = shotSpeed;
        shotscript.Shoot();
        shot = Instantiate(shotPrefab, (right.transform.position + new Vector3(0, 0.5f, 0)), Quaternion.identity);
        shotscript = shot.GetComponent<EffectShotScript>();
        shotscript.shotSpeed = shotSpeed;
        shotscript.Shoot();
    }
}
