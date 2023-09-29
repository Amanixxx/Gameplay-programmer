using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUP : MonoBehaviour
{
    private Health playerHealthScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealthScript = other.gameObject.GetComponent<Health>();
            playerHealthScript.healthamount+=0.3f;
         //   SoundManager.Instance.PlayCollectSound();
            Debug.Log("the Health is Up");
            Destroy(gameObject);
            // if meat tag then play chomp sound // if collictible then play that sound
        }
    }
}