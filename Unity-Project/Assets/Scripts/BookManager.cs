using UnityEngine;
using System.Collections.Generic;

public class BookManager : MonoBehaviour
{
    public GameObject bookPrefab; // Prefab do livro
    public Transform[] initialSpawnPoints; // Pontos iniciais onde os livros serão gerados
    public Transform playerHand; // Ponto onde o livro será segurado
    public int maxBooks = 5; // Máximo de livros na cena
    private List<GameObject> activeBooks = new List<GameObject>();

    private GameObject heldBook; // Livro atualmente segurado pelo jogador

    void Start()
    {
        // Spawn inicial dos livros
        foreach (Transform spawnPoint in initialSpawnPoints)
        {
            SpawnBook(spawnPoint.position);
        }
    }

    void Update()
    {
        // Verifica se todos os livros foram usados
        if (activeBooks.Count == 0)
        {
            RespawnBooks();
        }
    }

    void SpawnBook(Vector2 position)
    {
        GameObject book = Instantiate(bookPrefab, position, Quaternion.identity);
        activeBooks.Add(book);
    }

    void RespawnBooks()
    {
        foreach (Transform spawnPoint in initialSpawnPoints)
        {
            SpawnBook(spawnPoint.position);
        }
    }

    public void PickUpBook(GameObject book)
    {
        if (heldBook == null)
        {
            heldBook = book;
            heldBook.GetComponent<BookPickup>().enabled = false;
            heldBook.transform.position = playerHand.position;
            heldBook.transform.SetParent(playerHand);
            //heldBook.SetActive(false); // Desativa o livro no cenário

            Rigidbody2D rb = heldBook.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.None;
            heldBook.layer = LayerMask.NameToLayer("BookCaido");
            rb.velocity = Vector2.zero;
        }
    }

    public void ThrowBookAtVillain(Transform villain)
    {
        if (heldBook != null)
        {
            heldBook.SetActive(true); // Ativa o livro para ser arremessado
            heldBook.transform.SetParent(null);
            activeBooks.Remove(heldBook); // Remove o livro da lista de ativos
            
            Rigidbody2D rb = heldBook.GetComponent<Rigidbody2D>();
            //rb.constraints = RigidbodyConstraints2D.None;
            //heldBook.layer = LayerMask.NameToLayer("BookCaido");
            Vector2 direction = (villain.position - playerHand.position).normalized;
            rb.velocity = direction * 10f; // Ajuste a velocidade conforme necessário
            
            // Adiciona rotação ao livro
            heldBook.GetComponent<BookRotation>().StartRotation();

            heldBook = null; // Limpa o slot de livro segurado
        }
    }
}
