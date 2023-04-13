using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEffects : MonoBehaviour
{
    public AudioClip[] SoundEffects;
    private AudioSource _audioSource;
    private bool _isPlaying;
    private AudioClip _currentlyPlaying;
    public vThirdPersonMotor MovementMotorScript;
    // Start is called before the first frame update
    void Start()
    {
        _isPlaying = false;
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetAxis("Vertical") !=0 || Input.GetAxis("Horizontal") != 0) && !_isPlaying && MovementMotorScript.isGrounded)
        {
            _audioSource.pitch = Random.Range(1f,1.3f);
            _audioSource.volume = Random.Range(0.3f, 0.8f);

            if (MovementMotorScript.isSprinting)
            {
                //Debug.Log("Playing fast");
                _currentlyPlaying = SoundEffects[1];
            }
            else
            {
                //Debug.Log("Playing normal");
                _currentlyPlaying = SoundEffects[0];
            }
            _audioSource.PlayOneShot(_currentlyPlaying);
            _isPlaying = true;  
            StartCoroutine(WaitForClip());
        }
    }

    IEnumerator WaitForClip()
    {
        yield return new WaitForSeconds(_currentlyPlaying.length);
        _isPlaying = false;
    }
}

