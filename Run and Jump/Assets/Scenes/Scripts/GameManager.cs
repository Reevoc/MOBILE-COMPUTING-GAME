using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager current;


    void Awake()
    {

        if (current == null)
            current = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.current.PlayBackGround();   
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        UIManagerScript.current.GameStart();
        ScoreManagerScript.current.StartScore();


    }

    public void  GameOver()
    {

      
        ScoreManagerScript.current.StopScore();
        UIManagerScript.current.GameOver();


    }
}
