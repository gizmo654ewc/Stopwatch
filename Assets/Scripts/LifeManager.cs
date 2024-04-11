using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LifeManager : MonoBehaviour
{
    public GameObject lifeSprite;
    public int life;
    public GameObject gameManager;
    GameManager gm;

    private bool ex1 = false;
    private bool ex2 = false;

    public GameObject pointCounter;
    PointCounter pcscript;

    //life list = important to retrieve instantiate objects
    private List<GameObject> lifeList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        pcscript = pointCounter.GetComponent<PointCounter>();

        //instantiate # of lives on screen
        gm = gameManager.GetComponent<GameManager>();
        life = gm.startingLives;
        for (int i = 0; i< life - 1; i++)
        {
            GameObject heart = Instantiate(lifeSprite, transform.position + (new Vector3(.8f, 0) * i), Quaternion.identity);
            lifeList.Add(heart);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            lifeminus();
        }
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            lifeadd();
        }

        if (!ex1)
        {
            if (pcscript.score >= 100000)
            {
                Debug.Log("EXTEND==");
                lifeadd();
                ex1 = true;
            }
        }
        if (!ex2)
        {
            if (pcscript.score >= 300000)
            {
                Debug.Log("EXTEND==");
                lifeadd();
                ex2 = true;
            }
        }
    }

    //life up and life down methods
    //some logic to avoid hiccups, pretty self explanatory past that
    public void lifeadd()
    {
        if (life >= 8)
        {
            Debug.Log("dont count higher");
        }
        else if (life < 1)
        {
            Debug.Log("dont instantiate anything");
        }
        else if (life == 1)
        {
            GameObject heart = Instantiate(lifeSprite, transform.position, Quaternion.identity);
            lifeList.Add(heart);
        }
        else
        {
            GameObject heart = Instantiate(lifeSprite, transform.position + (new Vector3(.8f, 0) * (life - 1)), Quaternion.identity);
            lifeList.Add(heart);
        }
        life++;
        Debug.Log(life);
    }
    public void lifeminus()
    {
        if (life <= 1)
        {
            Debug.Log("out of health");
        }
        else if (life >= 9)
        {
            Debug.Log("too much health, dont delete anything");
        }
        else
        {
            Destroy(lifeList[life - 2]);
            lifeList.RemoveAt(life - 2);
        }
        life--;
        Debug.Log(life-1);
    }
}
