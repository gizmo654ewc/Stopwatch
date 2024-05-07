using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleExplosions : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject endTheGame;
    public bool end;
    private GameObject[] explosions;
    public int howLong;
    private float waitToEnd = 3f;
    private float currWTE;
    // Start is called before the first frame update
    void Start()
    {
        explosions = GameObject.FindGameObjectsWithTag("ExplosionPoints");
        currWTE = waitToEnd;
        StartCoroutine(explosionsStart());
    }

    // Update is called once per frame
    void Update()
    {
        currWTE -= Time.deltaTime;
        if (currWTE < 0)
        {
            Destroy(this.gameObject);
            if (end)
            {
                Instantiate(endTheGame);
            }
        }
    }

    IEnumerator explosionsStart()
    {
        for (int l = 0; l < howLong; l++)
        {
            for (int i = 0; i < explosions.Length; i++)
            {
                Instantiate(explosion, explosions[i].transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
