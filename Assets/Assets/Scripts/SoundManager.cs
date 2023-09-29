using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singlton
    public static SoundManager Instance { get; private set; } = null;
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    
    [SerializeField] private AudioSource _soundAudioSource;
   

    public AudioClip Jump,
        Walk,
        Fall,
        Attack,
        fire;

    public void PlayJumpSound()
    {
        _soundAudioSource.PlayOneShot(Jump);
    }
  
    public void PlayWalkSound()
    {
        _soundAudioSource.PlayOneShot(Walk);
    }

    public void PlayFallSound()
    {
        _soundAudioSource.PlayOneShot(Fall);
    }

    public void PlayAttackSound()
    {
        _soundAudioSource.PlayOneShot(Attack);
    }

    public void PlayFireSound()
    {
        _soundAudioSource.PlayOneShot(fire);
    }
    
}
