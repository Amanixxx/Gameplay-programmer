using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveXP : MonoBehaviour
{ 
    #region singleton
    public static SaveXP instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion;

    private int XPValue;
    private int MedValue;
  

    public int XPMethod
    { 
        get { return XPValue; }
        set { XPValue= value; }
    }
    public int MedMethod
    { 
        get { return MedValue; }
        set { MedValue= value; }
    }
}
