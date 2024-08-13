using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Objects[] slots; // Array de slots de inventário
    public Image[] slotImages; // Imagens dos slots de inventário
    private GameObject nearbyObject; // Objeto próximo para coleta
    public GameObject inventoryPanel; // Painel do inventário
    public GameObject reward; // Recompensa

    private string[] correctOrder = { "L", "O", "V", "E", "L", "A", "C", "E" };

    void Start()
    {
        slots = new Objects[slotImages.Length];

        for (int i = 0; i < slotImages.Length; i++)
        {
            int index = i;
            slotImages[i].gameObject.AddComponent<Button>();
            SlotDragHandler dragHandler = slotImages[i].gameObject.AddComponent<SlotDragHandler>();
            SlotDropHandler dropHandler = slotImages[i].gameObject.AddComponent<SlotDropHandler>();
            dragHandler.Initialize(this, index);
            dropHandler.Initialize(this, index);
        }

        if (reward != null)
        {
            reward.SetActive(false);
        }

        inventoryPanel.SetActive(false);
    }

    void Update()
    {
        if (inventoryPanel.activeInHierarchy) return;

        if (nearbyObject != null && Input.GetKeyDown(KeyCode.E))
        {
            ObjectType objectTypeComponent = nearbyObject.GetComponent<ObjectType>();
            if (objectTypeComponent != null)
            {
                Objects objectData = objectTypeComponent.objectType;
                if (objectData != null)
                {
                    Debug.Log("Adding item: " + objectData.itemName);
                    for (int i = 0; i < slots.Length; i++)
                    {
                        if (slots[i] == null)
                        {
                            slots[i] = objectData;
                            slotImages[i].sprite = objectData.itemSprite;
                            slotImages[i].color = Color.white;

                            // Desativar o objeto em vez de destruí-lo
                            nearbyObject.SetActive(false);
                            ClearNearbyObject();

                            CheckOrder();
                            break;
                        }
                    }
                }
            }
        }
    }

    // Método para definir o objeto próximo
    public void SetNearbyObject(GameObject obj)
    {
        nearbyObject = obj;
    }

    // Método para limpar o objeto próximo
    public void ClearNearbyObject()
    {
        nearbyObject = null;
    }

    // Método para trocar os itens de lugar no inventário
    public void SwapItems(int index1, int index2)
    {
        Objects temp = slots[index1];
        slots[index1] = slots[index2];
        slots[index2] = temp;

        Sprite tempSprite = slotImages[index1].sprite;
        slotImages[index1].sprite = slotImages[index2].sprite;
        slotImages[index2].sprite = tempSprite;
        slotImages[index1].color = slots[index1] != null ? Color.white : Color.clear;
        slotImages[index2].color = slots[index2] != null ? Color.white : Color.clear;

        CheckOrder();
    }

    // Método para soltar um item do inventário no mundo do jogo
    public void DropItem(int index, Vector3 position)
    {
        if (slots[index] != null)
        {
            GameObject itemPrefab = slots[index].objectPrefab;
            GameObject droppedItem = Instantiate(itemPrefab, position, Quaternion.identity);
            droppedItem.tag = "Object";
            droppedItem.AddComponent<ObjectType>().objectType = slots[index];
            slots[index] = null;
            slotImages[index].sprite = null;
            slotImages[index].color = Color.clear;
        }

        CheckOrder();
    }

    // Método para adicionar um item ao inventário
    public void AddItem(Objects item)
    {
        Debug.Log("Adding item: " + item.itemName);
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                slots[i] = item;
                slotImages[i].sprite = item.itemSprite;
                slotImages[i].color = Color.white;
                CheckOrder();
                return;
            }
        }
    }

    private void CheckOrder()
    {
        int[] targetSlots = { 0, 1, 2, 3, 8, 9, 10, 11 };
        for (int i = 0; i < correctOrder.Length; i++)
        {
            if (slots[targetSlots[i]] == null || slots[targetSlots[i]].itemName != correctOrder[i])
            {
                Debug.Log("Letras não estão na ordem correta");
                return;
            }
        }
        Debug.Log("Puzzle completo!");
        GiveReward();
    }

    private void GiveReward()
    {
        if (reward != null)
        {
            reward.SetActive(true);
        }
        Debug.Log("Recompensa recebida!");
    }

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
}
