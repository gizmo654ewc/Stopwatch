using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRouteMovement : MonoBehaviour
{
    public GameObject route1;
    public GameObject route2;
    public GameObject enemy;
    private GameObject emitter;
    Emitter_Basic emitScript;
    public float speed = 1;
    private bool route1_complete = false;
    private bool shooting_complete = false;
    // Start is called before the first frame update
    void Start()
    {
        enemy.transform.position = route1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        if (route1_complete == false)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, route2.transform.position, step);
        }
        else if (route1_complete == true && shooting_complete)
        {
            //shoot like 10 times
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
