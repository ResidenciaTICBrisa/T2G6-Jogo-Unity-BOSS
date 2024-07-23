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
        if (playerIsClose)
        {
            SceneManager.LoadScene(diaryScene, LoadSceneMode.Additive);

            StartCoroutine(SceneFullyLoaded());
            //canvas.isActive
        }
    }

    IEnumerator SceneFullyLoaded()
    {
        yield return null; // Espera um frame para garantir que a cena foi descarregada
        Scene sceneDiary = SceneManager.GetSceneByName(diaryScene);
        if (sceneDiary.isLoaded)
        {
            string name = gameObject.name + "-";
            GameObject[] diaries = GameObject.FindGameObjectsWithTag("Diary");
            Debug.Log(diaries.Length);
            for (int i = 0; i < diaries.Length; i++)
            {
                diaries[i].SetActive(false);
            }
            for (int i = 0; i < diaries.Length; i++)
            {
                if (diaries[i].name == name)
                {
                    diaries[i].SetActive(true);
                }
            }
        }
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
