using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MuteAudioBeforePlaying : MonoBehaviour
{
    private GameObject audS;
    private AudioSource audSource;
    [SerializeField] private AudioSource newMusic;
    // Start is called before the first frame update
    void Start()
    {
        audS = GameObject.FindWithTag("Music");
        audSource = audS.GetComponent<AudioSource>();
        audSource.Stop();
        newMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
