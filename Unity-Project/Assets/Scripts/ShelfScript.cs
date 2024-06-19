using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfScript : MonoBehaviour
{
    public GameObject exclamation; // Referência ao GameObject da exclamação
    private bool playerIsClose = false; // Verifica se o jogador está perto
    private AudioSource sound; // Som a ser reproduzido durante a interação

    // Start is called before the first frame update
    void Start()
    {
        if (exclamation != null)
        {
            exclamation.SetActive(false); // Inicialmente desativa a exclamação
        }
        else
        {
            Debug.LogError("No Exclamation GameObject found. Please assign it in the inspector.");
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (playerIsClose)
        {
            if (exclamation != null)
            {
                exclamation.SetActive(true);
            }
        }
        else
        {
            if (exclamation != null)
            {
                exclamation.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = true;
            if (exclamation != null)
            {
                exclamation.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
            if (exclamation != null)
            {
                exclamation.SetActive(false);
            }
        }
    }
}
