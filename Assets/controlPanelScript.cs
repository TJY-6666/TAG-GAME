using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class controlPanelScript : MonoBehaviour
{
    public GameObject controlPanelScene;
    public GameObject pauseButton;
    public bool pausePressed = false;

    public countDownScript countDownScript;

    public GameObject gameOverScene;
    public TextMeshProUGUI surviveTimeText;

    public timerScript timerScript;

    public void pause()
    {
        pausePressed = true;
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        controlPanelScene.SetActive(true);
    }

    public void resume()
    {
        pausePressed = false;

        if (!countDownScript.countDownPressed)
        {
            Time.timeScale = 1f;
        }

        controlPanelScene.SetActive(false);
        pauseButton.SetActive(true);

    }

    public void restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1f;
    }

    public void quitToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void gameOver()
    {
        pauseButton.SetActive(false);
        gameOverScene.SetActive(true);

        float elapsedTime = timerScript.GameData.ElapsedTime;

        int minute = Mathf.FloorToInt(elapsedTime / 60);
        int second = Mathf.FloorToInt(elapsedTime % 60);

        surviveTimeText.text ="SURVIVE TIME " + string.Format("{0:00}:{1:00}", minute, second);
    }


}
