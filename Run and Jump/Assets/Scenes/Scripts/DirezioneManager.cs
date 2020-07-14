using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirezioneManager : MonoBehaviour
{

    private bool partito;
    // Start is called before the first frame update
    void Start()
    {
        partito = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!partito)
        {
            if(Input.GetMouseButtonDown(0))

            partito = PallaController.current.IniziaPartita();
        }
    }


    public void CambiaDirezione()
    {
        if (!partito)
        {
          
            partito = PallaController.current.IniziaPartita();
        }

        else
            PallaController.current.CambiaDirezione();
    }
}
