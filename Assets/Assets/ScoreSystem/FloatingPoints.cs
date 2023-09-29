using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPoints : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     
      transform.localPosition += new Vector3(0, 1f, 0.5f);
      Destroy(gameObject,1f);
    }

   
}
