using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Delete : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, .7f);
    }
}
