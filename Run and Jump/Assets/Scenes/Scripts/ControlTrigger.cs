using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider col)
    {

        if(col.gameObject.tag == "Palla")
        {
            //chiamo la funzione che fa cadere la piattaforma dopo 0.5 secondi
            Invoke("PiattaformaCade", 1f);
               

        }

    }


    void PiattaformaCade()
    {

        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic= false;
        Destroy(transform.parent.gameObject, 2f);
        
    
    }
}
