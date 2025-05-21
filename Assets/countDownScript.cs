using System.Collections;
using UnityEngine;
using TMPro;

public class countDownScript : MonoBehaviour
{
    public int countDownNumber = 3;
    public TMP_Text countDownText;
    public Canvas canvasCountdown;
    public string countDownEndText = "GO!!!";

    public bool countDownPressed = true;
    public controlPanelScript controlPanelScript;

    private int countDownCount;
    private Coroutine countDownCoroutine;

    private void Start()
    {
        StartCountDown();
    }

    public void StartCountDown()
    {
        countDownPressed = true;
        countDownCount = countDownNumber;
        canvasCountdown.gameObject.SetActive(true);
        Time.timeScale = 0f;

        if (countDownCoroutine != null)
        {
            StopCoroutine(countDownCoroutine); // 确保没有其他运行中的协程
        }
        countDownCoroutine = StartCoroutine(CountDownCo());
    }

    private IEnumerator CountDownCo()
    {
        while (countDownCount >= 0)
        {
            if (!controlPanelScript.pausePressed)
            {
                if (countDownCount > 0)
                {
                    countDownText.text = countDownCount.ToString();
                }
                else
                {
                    countDownText.text = countDownEndText;
                }

                yield return new WaitForSecondsRealtime(1f);

                countDownCount--;

                if (countDownCount < 0)
                {
                    Debug.Log("finish");
                    canvasCountdown.gameObject.SetActive(false);
                    countDownPressed = false;
                    Time.timeScale = 1f;
                }
            }
            else
            {
                yield return null; // 暂停时等待下一帧
            }
        }
    }
}

