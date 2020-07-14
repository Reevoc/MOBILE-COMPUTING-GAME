using System.Collections;
using System.Collections.Generic;
using TinyJson;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class HighScoreController : MonoBehaviour
{

    public TextMeshProUGUI firstPosition;
    public TextMeshProUGUI secondPosition;
    public TextMeshProUGUI thirdPosition;

    public GameObject scrollView;
  /**  public GameObject playerScoreEntry;
    public TextMeshProUGUI playerHighScore; */

    // Start is called before the first frame update
    void Start()
    {
        //this.showPlayerHighScore();
        StartCoroutine(printAllHighScores());
    }

   /** private void showPlayerHighScore()
    {
        int highScore = PlayerPrefs.GetInt("highScore");
        this.playerHighScore.text = "You (" +PlayerPrefs.GetString("username") + "): " + highScore.ToString();
    } */

    private IEnumerator printAllHighScores()
    {
        string url = "http://comandiutili.altervista.org/highscore.php";
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("Web error");
        }

        string json = www.downloadHandler.text;
        fillScores(json.FromJson<List<HighScore>>());

        yield return json;
    }

    private void fillScores(List<HighScore> scores)
    {
        /** int position = 1;
        foreach(HighScore hs in scores)
        {
            //GameObject scorePlayer = Instantiate(generateText(hs.name + ": " + hs.score,Color.white)) as GameObject;
            GameObject scorePlayer = Instantiate(generateEntry(position,hs.name,hs.score)) as GameObject;
            scorePlayer.transform.SetParent(scrollView.transform, false);
            position++;
        } */
            firstPosition.text = scores[0].nome + ", " + scores[0].score;
            secondPosition.text = scores[1].nome + ", " + scores[1].score;
            thirdPosition.text = scores[2].nome + ", " + scores[2].score;
        

    }





}
