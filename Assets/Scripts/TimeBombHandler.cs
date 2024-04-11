using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBombHandler : MonoBehaviour
{
    public bool timeSlow = false;
    public bool circleDelete = false;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            timeSlow = false;
            player = GameObject.FindWithTag("Player");
        }

        if (timeSlow)
        {
            Time.timeScale = 0.3f;
        }
        else
        {
            Time.timeScale = 1;
            circleDelete = false;
        }
    }

    public IEnumerator StopWatch()
    {
        timeSlow = true;
        circleDelete = true;
        yield return new WaitForSecondsRealtime(0.1f);
        circleDelete = false;
        yield return new WaitForSecondsRealtime(4.9f);
        circleDelete = false;
        timeSlow = false;
    }
}
