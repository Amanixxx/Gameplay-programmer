using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class CollectThings : MonoBehaviour
{
  public int MedicineHandler = 0;
    public int XPHandler = 0;
    //  [SerializeField] private GameObject CollectMore;
    [SerializeField] private TextMeshProUGUI medicineCount;
    [SerializeField] private TextMeshProUGUI XPCount;
    [SerializeField] private GameObject floatingPoints;
    [SerializeField] private Health playerHealthScript;
    
    #region singleton
    public static CollectThings instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion;

    private void Update()
    {
        
        medicineCount.text = (""+PlayerPrefs.GetInt("MedValue"));
        XPCount.text = ("" + PlayerPrefs.GetInt("XPValue"));


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Medicine"))
        {
           
             MedicineHandler += 1;
            // SoundManager.Instance.PlayCollectSound();
             PlayerPrefs.SetInt("MedValue",MedicineHandler);
            GameObject points= Instantiate(floatingPoints, transform.position, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "+1";

            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("XP"))
        {
            
            XPHandler += 250;
          //  SoundManager.Instance.PlayCollectSound();
           PlayerPrefs.SetInt("XPValue",XPHandler);
            GameObject points= Instantiate(floatingPoints, transform.position, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "250";

            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Meat"))
        {
            playerHealthScript = this.GetComponent<Health>();
            playerHealthScript.healthamount+=0.3f;

            Debug.Log("the Health increased");
            Destroy(other.gameObject);
         //   SoundManager.Instance.PlayEatSound();
        }
    }

}