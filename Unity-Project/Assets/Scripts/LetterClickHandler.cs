using UnityEngine;

public class LetterClickHandler : MonoBehaviour
{
    public Objects letterObject; // O ScriptableObject da letra

    private void Start()
    {
        if (letterObject == null)
        {
            Debug.LogError("LetterObject não está atribuído no LetterClickHandler.");
        }
    }

    public void OnClick()
    {
        Debug.Log("OnClick chamado.");
        InventoryController inventoryController = FindObjectOfType<InventoryController>();
        if (inventoryController != null && letterObject != null)
        {
            inventoryController.AddItem(letterObject);
            Debug.Log($"Adicionando {letterObject.itemName} ao inventário.");
        }
        else
        {
            Debug.LogError("InventoryController não encontrado ou LetterObject não atribuído.");
        }
    }
}
