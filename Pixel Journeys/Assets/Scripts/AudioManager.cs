using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public AudioSource[] audioSource;

    private void Awake()
    {
        instance = this;   
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void audioSystem(int tracknumber)
    {
        audioSource[tracknumber].Stop();
        audioSource[tracknumber].Play();
    }
    public void audioStopper(int tracknumber)
    {
        audioSource[tracknumber].Stop();
    }
}
