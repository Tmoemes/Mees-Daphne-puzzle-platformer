using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEffects : MonoBehaviour
{
    public AudioClip[] SoundEffects;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            _audioSource.Play();
        }
    }
}
