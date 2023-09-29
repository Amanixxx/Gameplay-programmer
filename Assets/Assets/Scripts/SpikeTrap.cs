using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private GameObject FakeTrap;
    [SerializeField] private GameObject RealTrap;

    void Start()
    {
        FakeTrap.SetActive(true);
        RealTrap.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
         //   SoundManager.Instance.PlaySpikeSound();
            FakeTrap.SetActive(false);
            RealTrap.SetActive(true);
        }
    }
}
