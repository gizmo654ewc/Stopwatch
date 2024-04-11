using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerCounter : MonoBehaviour
{
    public int power = 0;
    private TMP_Text textcomp;
    // Start is called before the first frame update
    void Start()
    {
        textcomp = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (power >= 72) 
        {
            textcomp.color = Color.red;
            textcomp.text = "Power: MAX";
        }
        else
        {
            textcomp.color = Color.white;
            textcomp.text = "Power: " + power;
        }
    }
}
