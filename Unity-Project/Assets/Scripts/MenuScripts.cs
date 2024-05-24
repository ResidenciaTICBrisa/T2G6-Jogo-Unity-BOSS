using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
    AudioSource sound;

    void Start(){
        sound = GetComponent<AudioSource>();
        sound.Play();
    }
    public void ExitGame(){
        Debug.Log("Sair");
        Application.Quit();
    }

    public void StartGame(){
        SceneManager.LoadScene("SofiaHouse");
    }
    
}
