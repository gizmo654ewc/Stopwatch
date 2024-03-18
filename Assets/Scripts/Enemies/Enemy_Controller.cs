using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public GameObject enemy;
    Enemy_Behavior behavior;
    public GameObject emitter;
    Emitter_Basic emitScript;
    public GameObject sprite;

    public Enemy_Behavior.ShotChoice shotChoice;

    public int health;
    public float ShotWait;
    public int TimesFired;
    public float Cone_Wideness;
    public int ConeShotNum;
    public float Shot_Speed;
    public float Speed_Entering;
    public float Speed_Exiting;

    void Start()
    {
        behavior = enemy.GetComponent<Enemy_Behavior>();
        emitScript = emitter.GetComponent<Emitter_Basic>();
        behavior.health = health;
        behavior.shotWait = ShotWait;
        behavior.shotsFired = TimesFired;
        behavior.coneWide = Cone_Wideness;
        behavior.coneShotNum = ConeShotNum;
        emitScript.speed = Shot_Speed;
        behavior.durationEnter = Speed_Entering;
        behavior.durationLeave = Speed_Exiting;
        behavior.shotChoice = shotChoice;
    }

    void Update()
    {
        
    }
}
