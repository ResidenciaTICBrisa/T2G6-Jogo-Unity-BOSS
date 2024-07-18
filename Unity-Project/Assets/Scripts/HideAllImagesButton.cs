using UnityEngine;
using UnityEngine.UI;

public class HideAllImagesButton : MonoBehaviour
{
    public Button hideAllButton;  // O botão que ocultará todas as imagens
    private bool buttonActive;

    void Start()
    {
        // Inicialize a variável de estado do botão
        buttonActive = false;

        // Certifique-se de que o botão está definido e oculto no início
        if (hideAllButton != null)
        {
            hideAllButton.gameObject.SetActive(false);
            hideAllButton.onClick.AddListener(HideAllImages);
        }
        else
        {
            Debug.LogWarning("HideAllButton is not assigned.");
        }

        // Verifica se há alguma imagem visível no início do jogo
        bool anyImageVisible = IsAnyImageVisible();
        if (anyImageVisible)
        {
            hideAllButton.gameObject.SetActive(true);
            buttonActive = true;
        }

        // Log inicial para depuração
        Debug.Log("Initial check - Any image visible: " + anyImageVisible);
    }

    void Update()
    {
        // Verifica se há alguma imagem visível
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

        // Log para depuração
        Debug.Log("Any image visible: " + anyImageVisible);
    }

    void HideAllImages()
    {
        // Encontrar todas as imagens com a tag "HideableImage"
        GameObject[] allImages = GameObject.FindGameObjectsWithTag("HideableImage");

        // Iterar por todas as imagens e torná-las invisíveis
        foreach (GameObject img in allImages)
        {
            img.SetActive(false);
        }

        // Ocultar o botão após esconder todas as imagens
        hideAllButton.gameObject.SetActive(false);
        buttonActive = false;

        Debug.Log("All images hidden.");
    }

    bool IsAnyImageVisible()
    {
        // Encontrar todas as imagens com a tag "HideableImage"
        GameObject[] allImages = GameObject.FindGameObjectsWithTag("HideableImage");

        // Verificar se alguma imagem está visível
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