using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltaManager : MonoBehaviour
{


    // Start is called before the first frame update



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void invocaSalto()
    {
        if (Camera.main.GetComponent<CameraController>().gameOver == false)
            PallaController.current.Salta();

    }
}
