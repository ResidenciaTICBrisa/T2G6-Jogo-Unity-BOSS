using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueVilao : MonoBehaviour
{     
     public float Duracao = 2f;
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
       Duracao -= Time.deltaTime;
       if (Duracao <= 0){

         Destroy(gameObject);
       }   
    }
}
