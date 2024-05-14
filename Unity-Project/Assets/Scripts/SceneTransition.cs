using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//parte do código para ocorrer a transição e cena
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

    

//código para ocorrer o fade 

    public  static  Porta instance;
    [SerializeField] Animator TransitionAnim;

    public void NextLevel()
    {
        StartCoroutine(LoadLevel());

    }

    IEnumerator LoadLevel()
    {
        TransitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        TransitionAnim.SetTrigger("Start");
    }
   

}









