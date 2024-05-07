using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Porta : MonoBehaviour
{
    [SerializeField]
    private string NomeProximaCena; 

    private void OnTriggerEnter2D(Collider2D collision){
        IrProximaCena();

    }

    private void IrProximaCena(){
        SceneManager.LoadScene(NomeProximaCena);


    }
 



}
