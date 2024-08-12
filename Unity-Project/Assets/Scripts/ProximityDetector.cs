using UnityEngine;

public class ProximityDetector : MonoBehaviour
{
    public GameObject button;  // O botão que será ativado

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
        // Verifica se o jogador entrou na área de detecção
        if (other.CompareTag("Player"))
        {
            if (button != null)
            {
                button.SetActive(true);  // Torna o botão visível
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Verifica se o jogador saiu da área de detecção
        if (other.CompareTag("Player"))
        {
            if (button != null)
            {
                button.SetActive(false);  // Torna o botão invisível
            }
        }
    }
}
