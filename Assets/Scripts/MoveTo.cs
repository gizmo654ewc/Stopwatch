using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float speed;
    private Vector2 fromTo;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
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
}
