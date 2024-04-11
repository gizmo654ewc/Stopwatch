using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public int time = 0;
    private TMP_Text textcomp;
    // Start is called before the first frame update
    void Start()
    {
        textcomp = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 30)
        {
            textcomp.color = Color.magenta;
            textcomp.text = "Stopwatch: READY";
        }
        else
        {
            textcomp.color = Color.white;
            textcomp.text = "Stopwatch: " + time;
        }
    }
}
