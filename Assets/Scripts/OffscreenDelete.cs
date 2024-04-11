using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffscreenDelete : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
