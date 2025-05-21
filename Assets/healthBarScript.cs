using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarScript : MonoBehaviour
{

    public float maxHealth = 100;
    public float currentHelath;
    public Image healthBarFill;

    public playerScript playerScript;
    public controlPanelScript controlPanelScript;
    public countDownScript countDownScript;
    public bool playerDead = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHelath = maxHealth;
    }

    public void increaseHealth( float amountOfHealthChange)
    {
        currentHelath += amountOfHealthChange;
        updateHealthBar();
    }

    public void decreaseHealth( float amountOfHealthChange)
    {
        currentHelath -= amountOfHealthChange;
        updateHealthBar();

    }

    private void updateHealthBar()
    {
        float targetFillAmount = currentHelath / maxHealth;
        healthBarFill.fillAmount = targetFillAmount;
    }

    private void Update()
    {
        if (!controlPanelScript.pausePressed && !countDownScript.countDownPressed)
        {
            if (playerScript.hit)
            {
                decreaseHealth(0.03f);

            }
            else
            {
                increaseHealth(0.01f);
            }
        }

        if(healthBarFill.fillAmount == 0)
        {
            playerDead = true;
            controlPanelScript.gameOver();
        }

    }


}
