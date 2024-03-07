using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_OffScreen : MonoBehaviour
{
    public GameObject self;
    public GameObject sprite;
    Enemy_Behavior behavior;
    Invis_Check invis;
    // Start is called before the first frame update
    void Start()
    {
        behavior = self.GetComponent<Enemy_Behavior>();
        invis = sprite.GetComponent<Invis_Check>();
    }

    // Update is called once per frame
    void Update()
    {
        if (behavior.shooting_complete && invis.diss)
        {
            Destroy(this.gameObject);
        }
    }
}
