using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCollider : MonoBehaviour
{


    public GameObject effettoPart;
    
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
        if (col.transform.gameObject.tag == "Palla" && col.transform.gameObject.GetComponent<PallaController>().gameOver ==false)
        {
            GameObject part = Instantiate(effettoPart, col.gameObject.transform.position, Quaternion.identity) as GameObject;

            Camera.main.GetComponent<CameraController>().gameOver = true;
            GameManager.current.GameOver();

           
            Destroy(col.transform.gameObject.GetComponent<PallaController>().spawner.transform.gameObject);

       
            Destroy(col.transform.gameObject);
            
            
        }
    }


}
