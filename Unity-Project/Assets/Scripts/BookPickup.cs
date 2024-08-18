using UnityEngine;

public class BookPickup : MonoBehaviour
{
    private BookManager bookManager;

    void Start()
    {
        bookManager = FindObjectOfType<BookManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bookManager.PickUpBook(gameObject);
        }
    }
}
