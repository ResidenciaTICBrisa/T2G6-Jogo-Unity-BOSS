using UnityEngine;
using UnityEngine.UI;

public class ShowImageButton : MonoBehaviour
{
    public Button button;
    public GameObject image;

    void Start()
    {
        // Assegure-se de que o botão e a imagem estão definidos
        if (button != null && image != null)
        {
            // Tornar a imagem invisível no início
            image.SetActive(false);

            // Adicionar um listener ao botão para ativar a imagem quando clicado
            button.onClick.AddListener(ShowImage);
        }
        else
        {
            Debug.LogWarning("Button or Image is not assigned.");
        }
    }

    void ShowImage()
    {
        image.SetActive(true);
    }
}
