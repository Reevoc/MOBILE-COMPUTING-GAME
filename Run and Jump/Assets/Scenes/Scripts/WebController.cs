using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class WebController
{
    public IEnumerator printAllHighScores()
    {
        string url = "http://localhost/virusshooter/highscores.php";
        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("Web error");
        }

        yield return www.downloadHandler.text;
    }

    public IEnumerator printAllHighTimeScores()
    {
        string url = "http://localhost/virusshooter/hightimescores.php";
        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("Web error");
        }

        yield return www.downloadHandler.text;
    }

}
