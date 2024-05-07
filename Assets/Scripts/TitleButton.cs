using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public int WhatScene;
    public void MoveToScene()
    {
        SceneManager.LoadScene(WhatScene);
    }
}
