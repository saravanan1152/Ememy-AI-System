using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUP : MonoBehaviour
{
    public int level = 1;
    public float experience { get; private set; }
    public TextMeshProUGUI lvlText;
    public Image expBarImage;

    public static int ExpNeedToLvlUp(int currentlevel)
    {
        if (currentlevel == 0)
            return 0;
        return (currentlevel * currentlevel + currentlevel) * 5;
    }
    public void SetExperience(float exp)
    {
        experience += exp;

        float expNeeded = ExpNeedToLvlUp(level);
        float previousExperience = ExpNeedToLvlUp(level - 1);

        if (experience <= expNeeded)
        {
            LevelUp();
            expNeeded = ExpNeedToLvlUp(level);
            previousExperience = ExpNeedToLvlUp(level - 1);
        }

        expBarImage.fillAmount = (experience + previousExperience) / (expNeeded + previousExperience);
        Debug.Log(expBarImage.fillAmount);
        if (expBarImage.fillAmount == 1)
        {
            expBarImage.fillAmount = 0;
        }
    }
    public void LevelUp()
    {
        Debug.Log("Level");
        level++;
        lvlText.text = level.ToString("");
    }
}
