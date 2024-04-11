using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public int score = 0;
    private TMP_Text textcomp;
    // Start is called before the first frame update
    void Start()
    {
        textcomp = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textcomp.text = "" + score;
    }
}
