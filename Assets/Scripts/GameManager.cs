using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int startingLives;
    public int power;
    [SerializeField] private int time;
    [SerializeField] private float respawnTime;
    private int currentLives;
    [SerializeField] private GameObject powerUI;
    private PowerCounter powerCounter;
    [SerializeField] private GameObject timeUI;
    private TimeCounter timeCounter;


    public GameObject playerPrefab;
    private GameObject player;
    private PlayerController playerController;
    public GameObject lifeM;
    LifeManager lifeManager;
    Vector2 position;

    //audio
    [SerializeField] private AudioSource dieSource;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        lifeManager = lifeM.GetComponent<LifeManager>();
        playerController.power = power;
        playerController.time = time;
        powerCounter = powerUI.GetComponent<PowerCounter>();
        timeCounter = timeUI.GetComponent<TimeCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        currentLives = lifeManager.life;
        power = playerController.power;
        time = playerController.time;
        powerCounter.power = power;
        timeCounter.time = time;
        if (player != null)
        {
            position = player.transform.position;
        }
    }

    public void lifedown()
    {
        dieSource.Play();
        lifeManager.lifeminus();
        StartCoroutine(Revive());
    }

    IEnumerator Revive()
    {
        yield return new WaitForSeconds(respawnTime);
        if (currentLives < 1)
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            if (GameObject.FindWithTag("Player") == null)
            {
                player = Instantiate(playerPrefab, position, Quaternion.identity);
                playerController = player.GetComponent<PlayerController>();
                power = power - 6;
                playerController.power = power;
                playerController.time = time;
            }
            else
            {
                Debug.Log("bs");
            }
        }
    }
}
