using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfScript : MonoBehaviour
{
    public GameObject exclamation; // Referência ao GameObject da exclamação
    public Camera firstPersonCamera; // Câmera para visão em primeira pessoa
    public Camera thirdPersonCamera; // Câmera para visão em terceira pessoa
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

        if (firstPersonCamera != null)
        {
            firstPersonCamera.gameObject.SetActive(false); // Inicialmente desativa a câmera em primeira pessoa
        }
        else
        {
            Debug.LogError("No First Person Camera found. Please assign it in the inspector.");
        }

        if (thirdPersonCamera != null)
        {
            thirdPersonCamera.gameObject.SetActive(true); // Inicialmente ativa a câmera em terceira pessoa
        }
        else
        {
            Debug.LogError("No Third Person Camera found. Please assign it in the inspector.");
        }

        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (firstPersonCamera.gameObject.activeInHierarchy)
            {
                // Volta para a visão em terceira pessoa
                firstPersonCamera.gameObject.SetActive(false);
                thirdPersonCamera.gameObject.SetActive(true);
            }
            else
            {
                // Muda para a visão em primeira pessoa
                if (sound)
                {
                    sound.Play();
                }
                firstPersonCamera.gameObject.SetActive(true);
                thirdPersonCamera.gameObject.SetActive(false);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Q) && firstPersonCamera.gameObject.activeInHierarchy)
        {
            // Volta para a visão em terceira pessoa
            firstPersonCamera.gameObject.SetActive(false);
            thirdPersonCamera.gameObject.SetActive(true);
        }

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
