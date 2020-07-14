using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ScoreManagerScript : MonoBehaviour
{


    int score;
    int highScore;
    public static ScoreManagerScript current;

    void Awake()
    {
        if (current == null)
            current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
       


        //PER TEST
        //PlayerPrefs.SetInt("highScore", 10);

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void IncrementaScoreDiamond()
    {
        score += 2;
    }

    public void IncrementaScore()
    {
        score += 1;

    }



    public void StartScore()
    {

        InvokeRepeating("IncrementaScore", 0.1f, 1f);

    }



    public void StopScore()
    {
        
        CancelInvoke("IncrementaScore");

        //registro l'ultimo score ottenuto
        PlayerPrefs.SetInt("score", score);
        StartCoroutine(this.saveNewHighScore(score));
       
       

        //Registro l'high_score

        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            
                PlayerPrefs.SetInt("highScore", score);

               
            
            

        }
        else
            PlayerPrefs.SetInt("highScore", 0);

    }




    public int getScore()
    {
        return this.score;
    }

    private IEnumerator saveNewHighScore(int score)
    {
        string url = "http://comandiutili.altervista.org/insert_highscore.php";
        WWWForm form = new WWWForm();
        form.AddField("nome", PlayerPrefs.GetString("nome"));
        form.AddField("score", score);

        Debug.Log("Saving new high score online");

        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("Web error");
        }
    }


}
