using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    [SerializeField] int _score = 0;
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
 
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collectible touched ");
        if (other.gameObject.tag == "Collectible")
        {
            _score++;
            Debug.Log("collectible got! " + _score);
            _audioSource.PlayOneShot(SoundEffects[0]);
            Destroy(other.gameObject);
        }
    }
}
