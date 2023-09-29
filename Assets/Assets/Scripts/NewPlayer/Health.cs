using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class Health : MonoBehaviour
{
    public float healthamount = 1;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject bloodScreen;
    public Animator anim;
    //   [SerializeField] private Animator ChangeColor;

    void Start()
    {
        anim = GetComponent<Animator>();
        bloodScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = healthamount;
        if (healthamount <= 0.1f)
        {
            anim.SetTrigger("Death");
           // SoundManager.Instance.PlayHitSound();
            bloodScreen.SetActive(true);
            Debug.Log("player is dead");
               Invoke(loadLoseScrean("LoseScreen"), 3f);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("damege");
            healthamount -= 0.2f;
            bloodScreen.SetActive(true);
           // SoundManager.Instance.PlayHitSound();
        //    Shake.Instance.startShaking = true;
            StartCoroutine(BloodOff());
            //   ChangeColor.Play("ChangeColor");
        }

        else if (collision.gameObject.CompareTag("StrongEnemy"))
        {
            Debug.Log("Stronge damege");
            healthamount -= 0.4f;
           // SoundManager.Instance.PlayHitSound();
            bloodScreen.SetActive(true);
            StartCoroutine(BloodOff());
           
        }
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Bullet"))
    //     {
    //         healthamount -= 0.1f;
    //         SoundManager.Instance.PlayHitSound();
    //         bloodScreen.SetActive(true);
    //         Destroy(collision.collider.gameObject);
    //         StartCoroutine(BloodOff());
    //
    //     }
    // }

    IEnumerator BloodOff()
    {
        yield return new WaitForSeconds(1f);
        bloodScreen.SetActive(false);
    }
    public string loadLoseScrean(string nn)
    {
        SceneManager.LoadScene(nn);
        return nn;

    }


}