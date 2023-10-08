using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Update()
  
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // start the attack 
            animator.SetBool("Attack",true);
            Debug.Log("the player attake");
//            SoundManager.Instance.PlayAttackSound();
        }
        else
        {
                animator.SetBool("Attack",false);
                
        }
    }
}
