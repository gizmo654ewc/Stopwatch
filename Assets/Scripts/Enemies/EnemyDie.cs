using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public GameObject enemy;
    private void Start()
    {
        EnemyCollision dude = enemy.GetComponent<EnemyCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.GetComponent<EnemyCollision>().dead)
        {
            Destroy(this.gameObject);
        }
    }
}
