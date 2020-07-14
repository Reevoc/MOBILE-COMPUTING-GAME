using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PallaController : MonoBehaviour
{

    [SerializeField]
    private float speed;
    Rigidbody rb;
 
    public bool gameOver;
    public GameObject spawner;
    public GameObject particle;
    
    public GameObject jumpButton;
    public static PallaController current;

    //appena lanciata l'app
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        

    }

    // Update is called once per frame
    void Update()
    {
      
    

        if (!Physics.Raycast(transform.position, Vector3.down, 3f))
        {
            if (gameOver == false)
                GameManager.current.GameOver();

            gameOver = true;
            rb.velocity = new Vector3(0, -10f, 0);
            Camera.main.GetComponent<CameraController>().gameOver = true;

     
            

        }


        if (gameOver)
        {
           
            Destroy(spawner);

        }
    }


    public bool IniziaPartita()
    {
      
            rb.velocity = new Vector3(speed, 0, 0);
            spawner.GetComponent<SpawnerPiattaforma>().CominciaSpawn();
            GameManager.current.StartGame();
            return true;
        

    }


    public void Salta()

    {
                      

            if (rb.velocity.z > 0)
            {
                rb.velocity = new Vector3(0, 7, speed);


            }



            if (rb.velocity.x > 0)
            {
                rb.velocity = new Vector3(speed, 7, 0);


            }



        jumpButton.GetComponent<Button>().interactable = false;
    
        Invoke("FineSalto", 0.21f);
        Invoke("Finito", 0.64f);



    }


    void FineSalto()
    {


        if (rb.velocity.z > 0)
        {
        
            rb.velocity = new Vector3(0, 0, speed);

        }



        if (rb.velocity.x > 0)
        {

            rb.velocity = new Vector3(speed, 0, 0);

        }
            
        

    }

    void Finito()
    {
      
        jumpButton.GetComponent<Button>().interactable = true;
     
    }

   public void CambiaDirezione ()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }else
            if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }

    }


    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Diamond")
        {
            GameObject part=Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            ScoreManagerScript.current.IncrementaScoreDiamond();
            Destroy(col.gameObject);
            Destroy(part, 1.5f);

        }

    }
}
