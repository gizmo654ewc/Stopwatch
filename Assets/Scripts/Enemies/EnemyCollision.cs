using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int health;
    public bool dead;

    private void Start()
    {
        dead = false;
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "PlayerShot")
        {
            Debug.Log("hit");
            Destroy(col.gameObject);
            health--;
        }
    }

    void Update()
    {
        if (health == 0)
        {
            dead = true;
        }
    }

}
