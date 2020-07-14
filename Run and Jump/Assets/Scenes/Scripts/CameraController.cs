using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject palla;
    Vector3 offset;  //distanza tra la palla e la camera
    public float lerpRate;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        offset = palla.transform.position - transform.position; //calcolo della distanza tra palla e camera
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Segui();
        }
    }



    void Segui()
    {
        Vector3 pos = transform.position;  //posizione attuale camera
        Vector3 targetPos = palla.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
        
   }



}
