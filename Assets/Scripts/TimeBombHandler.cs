using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBombHandler : MonoBehaviour
{
    public bool timeSlow = false;
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
        }
    }

    public IEnumerator StopWatch()
    {
        timeSlow = true;
        yield return new WaitForSecondsRealtime(5f);
        timeSlow = false;
    }
}
