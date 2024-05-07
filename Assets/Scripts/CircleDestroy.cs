using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.parent.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyShot")
        {
            ES_Basic colS = collision.GetComponent<ES_Basic>();
            colS.inCricle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "EnemyShot")
        {
            ES_Basic colS = collision.GetComponent<ES_Basic>();
            colS.inCricle = false;
        }
    }
}
