using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private int level;

    [SerializeField] private float currentXp;

    [SerializeField] private float requiredXp;

    private float lerpTimer;

    private float delayTimer;

    [Header("UI - Bar")] 
    [SerializeField] private Image frontXpBar;
    [SerializeField] private Image BackXpBar;
    
    [Header("UI Text ")]
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI XPText;
    
    
    [Header("xp requierd lifeCycle")] 
    [Range(1f,300f)]
    [SerializeField] private float additionalMultiplier=300;
    [Range(2f,4f)]
    [SerializeField] private float powerMultiplier=2;
    [Range(7f,14f)]
    [SerializeField] private float divisionMaltiplier=7;
    
    // Start is called before the first frame update
    void Start()
    {
        frontXpBar.fillAmount = currentXp / requiredXp;
        BackXpBar.fillAmount = currentXp / requiredXp;
        // increase the requiered xp after each level up
        requiredXp = CalculateRequiredXp();
        levelText.text =   level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
     UpdateXpBar();
     if (Input.GetKeyDown(KeyCode.Equals))
     {
         GainXP(20);
     }
     // in this part we will check  if i can move to the next level :)
     if (currentXp > requiredXp)
     {
         LevelUp();
     }
    }
    
// this part for animate the xp increment and decrement
    public void UpdateXpBar()
    {
        float xpFraction = currentXp / requiredXp;
        float FillAmountXPBar = frontXpBar.fillAmount;
        if (FillAmountXPBar < xpFraction)
        {
            delayTimer += Time.deltaTime;
            BackXpBar.fillAmount = xpFraction;
            if (delayTimer > 3)
            {
                lerpTimer += Time.deltaTime;
                float precentComplate = lerpTimer / 4;
                frontXpBar.fillAmount = Mathf.Lerp(FillAmountXPBar, BackXpBar.fillAmount, precentComplate);
            }
        }

        XPText.text = currentXp + "/" + requiredXp;
    }
    //this part for gain the xp 
    public void GainXP(float xpGain)
    {
        currentXp += xpGain;
        lerpTimer = 0f;
    }
    
    //here the function for level up 
    public void LevelUp()
    {
        level++;
        frontXpBar.fillAmount = 0f;
        BackXpBar.fillAmount = 0f;
        // here we are set the remaining from the xp to add it to the bar after level up  
        currentXp = Mathf.RoundToInt(currentXp - requiredXp);
        requiredXp = CalculateRequiredXp();
        
        //update text for UI
        levelText.text = level.ToString();
        

    }
    //algorthim to make the required xp more over and over
    private int CalculateRequiredXp()
    {
        int solveForRequiredXp = 0;
        for (int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            //algorithm implement 
            solveForRequiredXp += (int)Mathf.Floor(levelCycle +additionalMultiplier * Mathf.Pow(powerMultiplier,levelCycle / divisionMaltiplier));
            
            
        }

        return solveForRequiredXp / 4;
    }
}
