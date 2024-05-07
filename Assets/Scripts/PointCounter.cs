using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public int score = 0;
    private TMP_Text textcomp;

    //datastorage
    private GameObject dataStorage;
    private DataStorage ds;

    // Start is called before the first frame update
    void Start()
    {
        //datas
        dataStorage = GameObject.FindWithTag("DataStorage");
        ds = dataStorage.GetComponent<DataStorage>();

        textcomp = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textcomp.text = "" + score;
        ds.score = score;
    }
}
