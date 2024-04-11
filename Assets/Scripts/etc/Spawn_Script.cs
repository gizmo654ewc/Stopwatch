using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Script : MonoBehaviour
{
    public GameObject spawnline;
    public GameObject spawned_enemy;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == spawnline)
        {
            Instantiate(spawned_enemy, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
