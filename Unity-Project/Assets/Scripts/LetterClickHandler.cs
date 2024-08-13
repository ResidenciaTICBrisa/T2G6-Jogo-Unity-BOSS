using UnityEngine;
using UnityEngine.UI;

public class LetterClickHandler : MonoBehaviour
{
    public Objects letterObject; // Referência ao objeto da letra
    private InventoryController inventoryController;

    void Start()
    {
        // Encontre o InventoryController na cena
        inventoryController = FindObjectOfType<InventoryController>();

        // Adiciona um componente Button, se ainda não tiver
        Button button = gameObject.AddComponent<Button>();

        // Configura o evento OnClick para chamar CollectLetter
        button.onClick.AddListener(CollectLetter);
    }

    void CollectLetter()
    {
        if (inventoryController != null && letterObject != null)
        {
            // Adiciona o objeto da letra ao inventário
            inventoryController.AddItem(letterObject);

            // Desativa a letra da estante (ou destrua o GameObject se desejar)
            gameObject.SetActive(false);
        }
    }
}
