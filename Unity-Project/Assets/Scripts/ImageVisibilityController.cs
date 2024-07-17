using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageVisibilityController : MonoBehaviour
{
    private GameObject hideAllButton;

    void Start()
    {
        // Encontrar o botão de ocultar todas as imagens no início
        hideAllButton = transform.Find("HideAllButton").gameObject;
        
        // Certifique-se de que o botão está oculto no início
        hideAllButton.SetActive(false);
    }

    void Update()
    {
        // Verifica se há alguma imagem visível
        bool anyImageVisible = IsAnyImageVisible();

        // Torna o botão visível se houver alguma imagem visível
        hideAllButton.SetActive(anyImageVisible);
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
                return true;
            }
        }
        return false;
    }

    public void HideAllImages()
    {
        // Encontrar todas as imagens com a tag "HideableImage"
        GameObject[] allImages = GameObject.FindGameObjectsWithTag("HideableImage");

        // Iterar por todas as imagens e torná-las invisíveis
        foreach (GameObject img in allImages)
        {
            img.SetActive(false);
        }

        // Atualizar o estado do botão após esconder todas as imagens
        hideAllButton.SetActive(false);
    }
}
