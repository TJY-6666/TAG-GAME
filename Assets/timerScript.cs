using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timerScript : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;

    public healthBarScript healthBarScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!healthBarScript.playerDead)
        {
            elapsedTime += Time.deltaTime;

            int minute = Mathf.FloorToInt(elapsedTime/60);
            int second = Mathf.FloorToInt(elapsedTime % 60);


            timerText.text = string.Format("{0:00}:{1:00}",minute,second);

            GameData.ElapsedTime = elapsedTime;

        }
    }

    public static class GameData
    {
        public static float ElapsedTime { get; set; }
    }
}
