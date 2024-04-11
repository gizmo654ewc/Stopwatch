using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToIfTime : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float speed;
    private Vector2 fromTo;

    public float autoCollectDistance;

    private GameObject timeBomb;
    TimeBombHandler timeBombHandler;

    // Start is called before the first frame update
    void Start()
    {
        timeBomb = GameObject.FindWithTag("TimeBombHandler");
        timeBombHandler = timeBomb.GetComponent<TimeBombHandler>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBombHandler.timeSlow)
        {
            if (player == null)
            {
                player = GameObject.FindWithTag("Player");
            }
            else
            {
                fromTo = player.transform.position - transform.position;
                fromTo.Normalize();
                transform.position = new Vector2(transform.position.x, transform.position.y) + fromTo * speed * Time.unscaledDeltaTime;
            }
        }
        if (player != null)
        {
            fromTo = player.transform.position - transform.position;
            if (fromTo.magnitude < autoCollectDistance)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y) + fromTo * speed * Time.unscaledDeltaTime;
            }
        }
        else
        {
            player = GameObject.FindWithTag("Player");
        }
    }
}
