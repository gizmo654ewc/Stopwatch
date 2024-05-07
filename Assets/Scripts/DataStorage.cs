using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    //check for stopwatch usage
    public bool stopwatchUsed = false;

    //scores
    public int score = 0;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
