using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximidadeEstante : MonoBehaviour
{
    public GameObject botaoInteragir; // Referência ao botão de interação
    public GameObject imagem; // Referência à imagem a ser mostrada

    void Start()
    {
        botaoInteragir.SetActive(false); // Certifique-se de que o botão está inicialmente desativado
        imagem.SetActive(false); // Certifique-se de que a imagem está inicialmente desativada
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            botaoInteragir.SetActive(true); // Mostra o botão de interação
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            botaoInteragir.SetActive(false); // Esconde o botão de interação
            imagem.SetActive(false); // Esconde a imagem caso o jogador saia da área sem clicar
        }
    }

    public void MostrarImagem()
    {
        imagem.SetActive(true); // Mostra a imagem quando o botão é clicado
    }
}

