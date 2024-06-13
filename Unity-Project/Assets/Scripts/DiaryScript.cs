using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiaryScript : MonoBehaviour
{
    public bool playerIsClose;

    private string diaryScene = "BookFlip";

    public GameObject canvas;

    public void ToggleInventory()
    {
        if (playerIsClose) SceneManager.LoadScene(diaryScene, LoadSceneMode.Additive);
        //canvas.isActive
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
