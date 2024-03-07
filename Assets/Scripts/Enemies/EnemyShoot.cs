using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject shot;
    public float autofireSpeed;
    private float currentFire;
    private bool readyShoot;

    // Start is called before the first frame update
    void Start()
    {
        currentFire = autofireSpeed;
        readyShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFire > 0)
        {
            currentFire -= Time.deltaTime;
        }
        if (readyShoot)
        {
            if (currentFire <= 0)
            {
                currentFire = autofireSpeed;
                GameObject shooter = Instantiate(shot, (transform.position), Quaternion.identity);
            }
        }
    }
}
