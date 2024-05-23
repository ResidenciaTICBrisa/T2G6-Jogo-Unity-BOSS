using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfScript : MonoBehaviour
{
    private bool playerInRange;

    public GameObject exclamation; // Referência ao GameObject da exclamação

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
        if (exclamation != null)
        {
            exclamation.SetActive(playerInRange);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
