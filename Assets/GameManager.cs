using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int startingLives;
    private int power;
    public GameObject player;
    private PlayerController playerController;
    public GameObject lifeM;
    LifeManager lifeManager;
    Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        lifeManager = lifeM.GetComponent<LifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        position = player.transform.position;
    }
}
