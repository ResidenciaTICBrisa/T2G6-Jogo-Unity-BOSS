using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryController : MonoBehaviour
{
    public Objects[] slots;
    public Image[] slotImage;
    private GameObject nearbyObject;
    public GameObject inventoryPanel;
    private GameObject draggedItem;

    private void Start()
    {
        slots = new Objects[slotImage.Length];

        for (int i = 0; i < slotImage.Length; i++)
        {
            int index = i;
            slotImage[i].gameObject.AddComponent<Button>();
            SlotDragHandler dragHandler = slotImage[i].gameObject.AddComponent<SlotDragHandler>();
            SlotDropHandler dropHandler = slotImage[i].gameObject.AddComponent<SlotDropHandler>();
            dragHandler.Initialize(this, index);
            dropHandler.Initialize(this, index);
        }
    }

    private void Update()
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
                        slotImage[i].color = Color.white; 
                        Destroy(nearbyObject);
                        nearbyObject = null;
                        break;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Object"))
        {
            nearbyObject = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Object"))
        {
            if (nearbyObject == other.gameObject)
            {
                nearbyObject = null;
            }
        }
    }

    public void SetNearbyObject(GameObject obj)
    {
        nearbyObject = obj;
    }

    public void ClearNearbyObject(GameObject obj)
    {
        if (nearbyObject == obj)
        {
            nearbyObject = null;
        }
    }

    public void SwapItems(int index1, int index2)
    {
        Objects temp = slots[index1];
        slots[index1] = slots[index2];
        slots[index2] = temp;

        Sprite tempSprite = slotImage[index1].sprite;
        slotImage[index1].sprite = slotImage[index2].sprite;
        slotImage[index2].sprite = tempSprite;
        slotImage[index1].color = slots[index1] != null ? Color.white : Color.clear;
        slotImage[index2].color = slots[index2] != null ? Color.white : Color.clear;
    }

    public void DropItem(int index, Vector3 position)
    {
        if (slots[index] != null)
        {
            GameObject itemPrefab = slots[index].objectPrefab; // Certifique-se de que Objects tenha uma referência ao prefab
            Instantiate(itemPrefab, position, Quaternion.identity);
            slots[index] = null;
            slotImage[index].sprite = null;
            slotImage[index].color = Color.clear;
        }
    }
}
