using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPiattaforma : MonoBehaviour
{

    public GameObject piattaforma;
    public GameObject piattaformaAlta;
    public GameObject diamond;
    public float velocitaDiSpawn;
    Vector3 ultimaPos;
    float size;
    
   

    // Start is called before the first frame update
    void Start()
    {
        ultimaPos = piattaforma.transform.position;
        size = piattaforma.transform.localScale.x;

        for(int i=0;i<1;i++)
        {
            
            SpawnPiattaforma();

        }

       
    }

    // Update is called once per frame
    void Update()
    {
   
    }


    public void CominciaSpawn()
    {
  
        InvokeRepeating("SpawnPiattaforma", 0.5f, velocitaDiSpawn);
        
        
        //Per Facile
        //InvokeRepeating("SpawnPiattaforma", 0.5f, 0.3f);

    }

     void SpawnPiattaforma()
    {
        int rand = Random.Range(0, 6);

        if (rand <3)
            Spawn('x');
        else
            
            Spawn('z');
                
              


    }

    void Spawn(char c)
    {
        Vector3 pos = ultimaPos;
        int rand1 = Random.Range(0, 6);

        if (c == 'x')
            pos.x += size;
        else

        if (c == 'z')
            pos.z += size;


        ultimaPos = pos;


        
        //Quaternion è la rotazione che diamo all'oggetto (identica a quella precendente ovvero 0)
        Instantiate(piattaforma, pos, Quaternion.identity);

        //Per modalità difficile
        if (DisabilitaManager.disabilitaNum != 1)
        {
            if (rand1 == 1 && c == 'x')
            {
                ultimaPos.y += size - 1;
                ultimaPos.x += size;
                Instantiate(piattaformaAlta, ultimaPos, Quaternion.identity);
            }
            else
            {

                if (rand1 == 1 && c == 'z')
                {
                    ultimaPos.y += size - 1;
                    ultimaPos.z += size;
                    Instantiate(piattaformaAlta, ultimaPos, Quaternion.identity);
                }


            }
        }
        

        int rand = Random.Range(0, 9);
        if(rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1.1f, pos.z), diamond.transform.rotation);
   
        }

    }

}
