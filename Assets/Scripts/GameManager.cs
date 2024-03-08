using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int startingLives;
    [SerializeField]
    private float respawnTime;
    private int power;
    private int currentLives;

    public GameObject playerPrefab;
    private GameObject player;
    private PlayerController playerController;
    public GameObject lifeM;
    LifeManager lifeManager;
    Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        lifeManager = lifeM.GetComponent<LifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentLives = lifeManager.life;
        if (player != null)
        {
            position = player.transform.position;
        }
    }

    public void lifedown()
    {
        lifeManager.lifeminus();
        StartCoroutine(Revive());
    }

    IEnumerator Revive()
    {
        yield return new WaitForSeconds(respawnTime);
        player = Instantiate(playerPrefab, position, Quaternion.identity);
    }
}
