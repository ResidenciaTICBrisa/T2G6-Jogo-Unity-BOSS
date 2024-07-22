using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageVisibilityController : MonoBehaviour
{
    private GameObject hideAllButton;

    void Start()
    {
        
        hideAllButton = transform.Find("HideAllButton").gameObject;
        
        
        hideAllButton.SetActive(false);
    }

    void Update()
    {
        
        bool anyImageVisible = IsAnyImageVisible();

        
        hideAllButton.SetActive(anyImageVisible);
    }

    bool IsAnyImageVisible()
    {
        
        GameObject[] allImages = GameObject.FindGameObjectsWithTag("HideableImage");

        
        foreach (GameObject img in allImages)
        {
            if (img.activeSelf)
            {
                return true;
            }
        }
        return false;
    }

    public void HideAllImages()
    {
        
        GameObject[] allImages = GameObject.FindGameObjectsWithTag("HideableImage");

        
        foreach (GameObject img in allImages)
        {
            img.SetActive(false);
        }

        
        hideAllButton.SetActive(false);
    }
}
