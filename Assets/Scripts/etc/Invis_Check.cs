using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Invis_Check : MonoBehaviour
{
    public bool diss = false;
    void OnBecameInvisible()
    {
        diss = true;
    }
    void OnBecameVisible()
    {
        diss = false;
    }
}
