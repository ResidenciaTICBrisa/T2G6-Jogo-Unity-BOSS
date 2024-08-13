using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShelfScript : MonoBehaviour
{
    public GameObject exclamation; // Referência ao GameObject da exclamação
    public Objects letterObject; // Referência à letra a ser coletada
    public GameObject firstPersonShelfView; // A visão da estante em primeira pessoa
    public GameObject closeButton; // Botão de fechar a visão em primeira pessoa
    private bool playerIsClose = false; // Verifica se o jogador está perto
    private InventoryController inventoryController;

    void Start()
    {
        if (exclamation != null)
        {
            exclamation.SetActive(false); // Inicialmente desativa a exclamação
        }

        inventoryController = FindObjectOfType<InventoryController>();

        if (firstPersonShelfView != null)
        {
            firstPersonShelfView.SetActive(false); // Inicialmente desativa a visão em primeira pessoa
        }
        if (closeButton != null)
        {
            closeButton.SetActive(false); // Inicialmente desativa o botão de fechar
        }
    }

    void Update()
    {
        if (playerIsClose && Input.GetKeyDown(KeyCode.E)) // Pressionar 'E' para interagir
        {
            OpenShelfView(); // Abre a visão em primeira pessoa da estante
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = true;
            exclamation.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
            exclamation.SetActive(false);
        }
    }

    public void OpenShelfView()
    {
        if (firstPersonShelfView != null)
        {
            firstPersonShelfView.SetActive(true); // Mostra a visão em primeira pessoa
        }
        if (closeButton != null)
        {
            closeButton.SetActive(true); // Mostra o botão de fechar
        }
    }

    public void CollectLetter()
    {
        if (inventoryController != null && letterObject != null)
        {
            inventoryController.AddItem(letterObject); // Adiciona a letra ao inventário
            firstPersonShelfView.SetActive(false); // Fecha a visão em primeira pessoa após a coleta
            closeButton.SetActive(false);
        }
    }

    public void CloseShelfView()
    {
        if (firstPersonShelfView != null)
        {
            firstPersonShelfView.SetActive(false); // Fecha a visão em primeira pessoa
        }
        if (closeButton != null)
        {
            closeButton.SetActive(false); // Esconde o botão de fechar
        }
    }
}
