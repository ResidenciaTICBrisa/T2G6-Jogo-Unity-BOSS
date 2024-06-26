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
}

public class SlotDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private InventoryController inventoryController;
    public int slotIndex; 
    private Image itemImage;
    private GameObject draggedItem;

    private Color originalColor;

    public void Initialize(InventoryController controller, int index)
    {
        inventoryController = controller;
        slotIndex = index;
        itemImage = GetComponent<Image>();
        originalColor = itemImage.color; 
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemImage.sprite == null) return;

        draggedItem = new GameObject("DraggedItem");
        draggedItem.transform.SetParent(transform.root, false);
        draggedItem.transform.SetAsLastSibling();
        Image draggedItemImage = draggedItem.AddComponent<Image>();
        draggedItemImage.sprite = itemImage.sprite;
        draggedItemImage.raycastTarget = false;
        RectTransform rectTransform = draggedItem.GetComponent<RectTransform>();
        rectTransform.sizeDelta = itemImage.GetComponent<RectTransform>().sizeDelta;
        draggedItemImage.color = itemImage.color;
        itemImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggedItem != null)
        {
            draggedItem.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggedItem != null)
        {
            Destroy(draggedItem);
        }
        itemImage.color = originalColor;
    }
}

public class SlotDropHandler : MonoBehaviour, IDropHandler
{
    private InventoryController inventoryController;
    private int slotIndex;

    public void Initialize(InventoryController controller, int index)
    {
        inventoryController = controller;
        slotIndex = index;
    }

    public void OnDrop(PointerEventData eventData)
    {
        SlotDragHandler draggedSlot = eventData.pointerDrag.GetComponent<SlotDragHandler>();
        if (draggedSlot != null)
        {
            int draggedSlotIndex = draggedSlot.slotIndex;
            inventoryController.SwapItems(draggedSlotIndex, slotIndex);
        }
    }
}