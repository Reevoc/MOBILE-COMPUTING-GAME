using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisabilitaManager : MonoBehaviour
{

   
    public static int disabilitaNum;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Awake()
    {
        caricaScenaNonFac();   
    }


    public void caricaScenaNonFac()
    {
        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByBuildIndex(3)))
        {
            disabilitaNum = 0;
        }
        else
            disabilitaNum = 1;
    }


    






}
