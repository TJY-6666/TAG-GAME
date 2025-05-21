using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class inputFieldScript : MonoBehaviour
{

    public InputField inputField;

    string URL = "https://docs.google.com/forms/d/e/1FAIpQLSf1Ashi2pAWuO50BmNmhJPcw2TaO0KebPnVSGOoozqqP8m2Cw/viewform?usp=sf_link";


    public void Send()
    {
        StartCoroutine(Post(inputField.text));
        
    }

    IEnumerator Post(string s1)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.2147303499", s1);




        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        yield return www.SendWebRequest();

        inputField.text = "";

    }


}