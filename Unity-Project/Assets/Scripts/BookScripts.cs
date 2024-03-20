using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookScripts : MonoBehaviour
{
    AudioSource sound;

    void Start(){
        sound = GetComponent<AudioSource>();
    }

    public void PlayBook(){
        sound.Play();
        if(sound.isPlaying){Debug.Log("Saindo");}
        else{Debug.Log("Mamammos");}
    }

    public void PlayPaper(){
        sound.Play();
    }

}