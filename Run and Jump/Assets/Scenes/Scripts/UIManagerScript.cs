using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
   
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject cliccaText;
    public GameObject jumpButton;
    public GameObject direzioneButton;
    public GameObject soundButton;
    public GameObject displayScorePanel;
    public GameObject displayHighScorePanel;
    public Text score;
    public Text highScore1;
    public Text highScore2;
    public Text displayScore;
    public Text displayHighScore;
    bool attivato = false;
    public static UIManagerScript current;
 
   

    void Awake()
    {
        if(current == null)
        current = this;
        
    }



    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("highScore"))
            highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
        else
            highScore1.text = "High Score: 0";
        
    }

    // Update is called once per frame
    void Update()
    {
        displayScore.text = "Score : " + ScoreManagerScript.current.getScore();

        if (PlayerPrefs.GetInt("highScore") <= ScoreManagerScript.current.getScore()) {

            if (!attivato)
            {
                AudioManager.current.PlaySound();
                displayHighScorePanel.SetActive(true);
                displayScorePanel.SetActive(false);
                attivato = true;
            }         

        displayHighScore.text = "HighScore : " + ScoreManagerScript.current.getScore(); }

    }




    public void GameStart()
    {
        cliccaText.GetComponent<Animator>().Play("textDisappear");

        startPanel.GetComponent<Animator>().Play("StartPanelDisappear");

        jumpButton.SetActive(true);
        direzioneButton.SetActive(true);
        Invoke("setSoundFalse", 0.2f);


    
        displayScorePanel.SetActive(true);
       
    }



    public void setSoundFalse()
    {
        soundButton.SetActive(false);
    }


    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive (true);
        displayHighScorePanel.SetActive(false);
        displayScorePanel.SetActive(false);
        jumpButton.SetActive(false);
        direzioneButton.SetActive(false);

    }

    public void Riparti()
    {

        SceneManager.LoadScene(2);

    }


    public void RipartiMed()
    {

        SceneManager.LoadScene(1);

    }

    public void tornaMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void tornaDif()
    {
        SceneManager.LoadScene(3);
    }
}
