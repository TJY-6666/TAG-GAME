using UnityEngine;

public class timeManagerScript : MonoBehaviour
{

    public float slowDownFactor = 0.05f;
    public float slowDownLength = 2f;
    public controlPanelScript controlPanelScript;
    public countDownScript countDownScript;
    public healthBarScript healthBarScript;

    private void Update()
    {

        if (!controlPanelScript.pausePressed && !countDownScript.countDownPressed)
        {
        Time.timeScale += (1 / slowDownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }

        if (healthBarScript.playerDead)
        {
            Time.timeScale = 0f;
        }
    }

    public void slowMotion()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
 
}
