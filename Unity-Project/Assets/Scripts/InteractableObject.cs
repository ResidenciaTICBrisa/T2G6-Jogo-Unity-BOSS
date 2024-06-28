using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private InventoryController inventoryController;

    private void Start()
    {
        inventoryController = FindObjectOfType<InventoryController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inventoryController.SetNearbyObject(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inventoryController.ClearNearbyObject(gameObject);
        }
    }
}
