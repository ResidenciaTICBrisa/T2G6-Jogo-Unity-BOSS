using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 // Certifique-se de ter o namespace correto

public class ShelfScript : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D light2D; // Referência ao componente Light2D
    public float activationDistance = 5f; // Distância para ativar a luz
    private bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        if (light2D == null)
        {
            light2D = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
            if (light2D == null)
            {
                Debug.LogError("No Light2D component found on this object.");
            }
        }
        light2D.enabled = false; // Inicialmente desativa a luz
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            light2D.enabled = true;
        }
        else
        {
            light2D.enabled = false;
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
