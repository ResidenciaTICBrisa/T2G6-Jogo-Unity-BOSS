using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Objects[] slots; // Inventário que armazena os ScriptableObjects
    public Image[] slotImage; // Imagens das slots do inventário
    private GameObject nearbyObject; // Objeto próximo que o jogador pode pegar

    void Start()
    {
        // Inicialize slots e slotImage se necessário
    }

    void Update()
    {
        if (nearbyObject != null && Input.GetKeyDown(KeyCode.E))
        {
            ObjectType objectType = nearbyObject.GetComponent<ObjectType>();
            if (objectType != null)
            {
                for (int i = 0; i < slots.Length; i++)
                {
                    if (slots[i] == null)
                    {
                        slots[i] = objectType.objectType;
                        slotImage[i].sprite = objectType.objectType.itemSprite;
                        Destroy(nearbyObject);
                        nearbyObject = null;
                        break;
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Object"))
        {
            nearbyObject = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Object"))
        {
            if (nearbyObject == other.gameObject)
            {
                nearbyObject = null;
            }
        }
    }
}
