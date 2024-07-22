using UnityEngine;
using UnityEngine.UI;

public class HideAllImagesButton : MonoBehaviour
{
    public Button hideAllButton;  
    private bool buttonActive;

    void Start()
    {
        
        buttonActive = false;

        if (hideAllButton != null)
        {
            hideAllButton.gameObject.SetActive(false);
            hideAllButton.onClick.AddListener(HideAllImages);
        }
        else
        {
            Debug.LogWarning("HideAllButton is not assigned.");
        }

       
        bool anyImageVisible = IsAnyImageVisible();
        if (anyImageVisible)
        {
            hideAllButton.gameObject.SetActive(true);
            buttonActive = true;
        }

        
        Debug.Log("Initial check - Any image visible: " + anyImageVisible);
    }

    void Update()
    {
        
        bool anyImageVisible = IsAnyImageVisible();

        // Torna o botão visível se houver alguma imagem visível
        if (anyImageVisible && !buttonActive)
        {
            hideAllButton.gameObject.SetActive(true);
            buttonActive = true;
        }
        else if (!anyImageVisible && buttonActive)
        {
            hideAllButton.gameObject.SetActive(false);
            buttonActive = false;
        }

        
        Debug.Log("Any image visible: " + anyImageVisible);
    }

    void HideAllImages()
    {
        
        GameObject[] allImages = GameObject.FindGameObjectsWithTag("HideableImage");

        
        foreach (GameObject img in allImages)
        {
            img.SetActive(false);
        }

       
        hideAllButton.gameObject.SetActive(false);
        buttonActive = false;

        Debug.Log("All images hidden.");
    }

    bool IsAnyImageVisible()
    {
        
        GameObject[] allImages = GameObject.FindGameObjectsWithTag("HideableImage");

        
        foreach (GameObject img in allImages)
        {
            if (img.activeSelf)
            {
                Debug.Log("Image visible: " + img.name);
                return true;
            }
        }
        return false;
    }
}
