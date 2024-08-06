using UnityEngine;
using UnityEngine.UI;

public class ProximityDetector : MonoBehaviour
{
    public GameObject button;  // O botão que será ativado
    private bool isNearShelf = false;

    void Start()
    {
        // Certifique-se de que o botão está invisível no início
        if (button != null)
        {
            button.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se a personagem entrou na área de detecção
        if (other.CompareTag("Player"))
        {
            isNearShelf = true;
            button.SetActive(true);  // Torna o botão visível
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Verifica se a personagem saiu da área de detecção
        if (other.CompareTag("Player"))
        {
            isNearShelf = false;
            button.SetActive(false);  // Torna o botão invisível
        }
    }
}