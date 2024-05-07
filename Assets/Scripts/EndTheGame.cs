using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTheGame : MonoBehaviour
{
    public int scene;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(scene);
    }
}
