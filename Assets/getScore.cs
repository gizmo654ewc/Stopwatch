using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class getScore : MonoBehaviour
{
    //datastorage
    private GameObject dataStorage;
    private DataStorage ds;

    private TMP_Text textcomp;

    // Start is called before the first frame update
    void Start()
    {
        //datas
        dataStorage = GameObject.FindWithTag("DataStorage");
        ds = dataStorage.GetComponent<DataStorage>();

        textcomp = GetComponent<TMP_Text>();
        textcomp.text = "" + ds.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
