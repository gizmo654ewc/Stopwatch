using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public GameObject lifeSprite;
    private int life;
    public GameObject gameManager;
    GameManager gm;

    //life list = important to retrieve instantiate objects
    private List<GameObject> lifeList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
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
            lifeDown();
        }
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            lifeUp();
        }
    }

    //life up and life down methods
    //some logic to avoid hiccups, pretty self explanatory past that
    public void lifeUp()
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
    public void lifeDown()
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
        Debug.Log(life);
    }
}
