using UnityEngine;

public class ShelfScript : MonoBehaviour
{
    public Objects letterObject; // Referência à letra a ser coletada
    private InventoryController inventoryController;
    public GameObject letterImage; // Referência ao GameObject da imagem da letra

    void Start()
    {
        inventoryController = FindObjectOfType<InventoryController>();

        // Inicialmente desativa a imagem da letra na estante
        if (letterImage != null)
        {
            letterImage.SetActive(true);
        }
    }

    void Update()
    {
        // A lógica de interação foi removida, pois não precisamos mais da visão em primeira pessoa e do botão de fechar
    }

    public void CollectLetter()
    {
        Debug.Log("CollectLetter chamado.");
        if (inventoryController != null && letterObject != null)
        {
            inventoryController.AddItem(letterObject); // Adiciona a letra ao inventário
            Debug.Log($"Adicionando {letterObject.itemName} ao inventário.");

            // Desativa a imagem da letra na estante
            if (letterImage != null)
            {
                letterImage.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("InventoryController ou LetterObject não estão atribuídos.");
        }
    }
}
