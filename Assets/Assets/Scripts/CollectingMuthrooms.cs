using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectingMuthrooms : MonoBehaviour
{
 
     public int MHandler = 0;
    
    
     [SerializeField] private TextMeshProUGUI MHCount;
     
     #region singleton
     public static CollectingMuthrooms instance;
     private void Awake()
     {
         instance = this;
     }
     #endregion;
 
     private void Update()
     {
         MHCount.text = "" + MHandler;
 
 
     }
 
     private void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.CompareTag("Mushroom"))
         {
             
             MHandler += 250;
         //    SoundManager.Instance.PlayCollectSound();
 
             Destroy(other.gameObject);
         }
     }

}
