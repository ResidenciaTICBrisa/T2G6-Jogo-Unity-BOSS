using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Objects[] slots; 
    public Image[] slotImage;     
    private GameObject nearbyObject;
    public GameObject inventoryPanel;

    private int selectedSlotIndex = -1; 

    void Start()
    {
        slots = new Objects[slotImage.Length];

        for (int i = 0; i < slotImage.Length; i++)
        {
            int index = i; 
            slotImage[i].gameObject.AddComponent<Button>(); 
            slotImage[i].GetComponent<Button>().onClick.AddListener(() => OnSlotClick(index)); 
        }
    }

    void Update()
    {
        if (inventoryPanel.activeInHierarchy) return;

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

    void OnSlotClick(int index)
    {
        if (selectedSlotIndex == -1)
        {
            selectedSlotIndex = index;
            Debug.Log("Slot selecionado: " + index);
        }
        else
        {
            SwapItems(selectedSlotIndex, index);
            Debug.Log("Itens trocados: " + selectedSlotIndex + " com " + index);
            selectedSlotIndex = -1; 
        }
    }

    void SwapItems(int index1, int index2)
    {
        Objects temp = slots[index1];
        slots[index1] = slots[index2];
        slots[index2] = temp;

        Sprite tempSprite = slotImage[index1].sprite;
        slotImage[index1].sprite = slotImage[index2].sprite;
        slotImage[index2].sprite = tempSprite;
    }
}
