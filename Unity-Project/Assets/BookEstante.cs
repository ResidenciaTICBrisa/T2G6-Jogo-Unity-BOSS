using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BookEstante : MonoBehaviour
{
    public void Store() {
        SceneManager.LoadScene("OpenBook", LoadSceneMode.Additive);
    }
}