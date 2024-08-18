using UnityEngine;

public class BookPickup : MonoBehaviour
{
    private BookManager bookManager;

    void Start()
    {
        bookManager = FindObjectOfType<BookManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bookManager.PickUpBook(gameObject);
            gameObject.SetActive(false); // Esconde o livro da cena
        }
    }
}
