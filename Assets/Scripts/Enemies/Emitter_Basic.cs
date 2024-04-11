using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Emitter_Basic : MonoBehaviour
{
    public GameObject shot1;
    ES_Basic shotScript;
    private GameObject aimedShot;
    public float range;
    public int num;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    //instantiates a shot, then aims it at the player
    public void S_Aimed()
    {
        aimedShot = Instantiate(shot1, (transform.position), Quaternion.identity);
        shotScript = aimedShot.GetComponent<ES_Basic>();
        shotScript.speed = speed;
        shotScript.Aimed();
    }
    //instantiates a shot, then aims it slightly away from the player
    //mainly for testing purposes
    public void S_AimedOffset(float deg)
    {
        aimedShot = Instantiate(shot1, (transform.position), Quaternion.identity);
        shotScript = aimedShot.GetComponent<ES_Basic>();
        shotScript.speed = speed;
        shotScript.AimedOffset(deg);
    }
    //instantiates 2 shots, then aims them both slightly away from the player
    public void S_Around(float deg)
    {
        aimedShot = Instantiate(shot1, (transform.position), Quaternion.identity);
        shotScript = aimedShot.GetComponent<ES_Basic>();
        shotScript.speed = speed;
        shotScript.AimedOffset(deg);
        aimedShot = Instantiate(shot1, (transform.position), Quaternion.identity);
        shotScript = aimedShot.GetComponent<ES_Basic>();
        shotScript.speed = speed;
        shotScript.AimedOffset(-deg);
    }
    //shoots an aimed cone at the player, with the range of shots and amount of shots as inputs
    public void S_AimedCone(float range, int num)
    {
        if (num < 0)
        {
            Debug.Log("You cannot shoot negative bullets");
        }
        else if (num == 1)
        {
            S_Aimed();
        }
        else
        {
            for (int i = 0; i < num; i++)
            {
                aimedShot = Instantiate(shot1, (transform.position), Quaternion.identity);
                shotScript = aimedShot.GetComponent<ES_Basic>();
                shotScript.speed = speed;
                shotScript.AimedOffset((range / (num - 1)) * i - (range / 2));
            }
        }
    }
    public void S_Static(float dir, int num, float range)
    {
        if (num < 0)
        {
            Debug.Log("You cannot shoot negative bullets");
        }
        else if (num == 1)
        {
            aimedShot = Instantiate(shot1, (transform.position), Quaternion.identity);
            shotScript = aimedShot.GetComponent<ES_Basic>();
            shotScript.speed = speed;
            shotScript.Static(dir);
        }
        else
        {
            for (int i = 0; i < num; i++)
            {
                aimedShot = Instantiate(shot1, (transform.position), Quaternion.identity);
                shotScript = aimedShot.GetComponent<ES_Basic>();
                shotScript.speed = speed;
                shotScript.Static((range / (num - 1)) * i - (range / 2) + dir);
            }
        }
    }

}
