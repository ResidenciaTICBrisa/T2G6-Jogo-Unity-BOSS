using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
//este script deve estar no seu Player e deve ter o nome "SalvarPosic"
public class SalvarPosic : MonoBehaviour {

 string nomeCenaAtual;

 void Awake () {
 nomeCenaAtual = SceneManager.GetActiveScene ().name;
 }

 void Start(){
 if (PlayerPrefs.HasKey (nomeCenaAtual + "X") && PlayerPrefs.HasKey (nomeCenaAtual + "Y")) {
 transform.position = new Vector3 (PlayerPrefs.GetFloat (nomeCenaAtual + "X"), PlayerPrefs.GetFloat (nomeCenaAtual + "Y"));
 }
 }

 public void SalvarLocalizacao () {
 PlayerPrefs.SetFloat (nomeCenaAtual + "X", transform.position.x);
 PlayerPrefs.SetFloat (nomeCenaAtual + "Y", transform.position.y);
 }
}