using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public int time = 0;
    private TMP_Text textcomp;

    private GameObject player;
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        textcomp = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
            if (time >= playerController.timeMax)
            {
                textcomp.color = Color.magenta;
                textcomp.text = "Stopwatch: READY";
            }
            else
            {
                textcomp.color = Color.white;
                textcomp.text = "Stopwatch: " + time + "/" + playerController.timeMax;
            }
        }
        else
        {
            player = GameObject.FindWithTag("Player");
        }
    }
}
