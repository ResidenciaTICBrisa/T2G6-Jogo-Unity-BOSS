using UnityEngine;

public class PlayerHandPosition : MonoBehaviour
{
    public Transform player; // Referência ao Transform do jogador
    public Vector3 offset = new Vector3(-0.2f, 0.5f, 0f); // Deslocamento em relação ao jogador

    void Update()
    {
        // Atualiza a posição do PlayerHand com base na posição do jogador e no deslocamento
        transform.position = player.position + offset;
    }
}
