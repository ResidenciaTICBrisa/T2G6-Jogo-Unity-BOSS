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
    public GameObject reward; // A chave ou recompensa
    public Objects[] correctOrder; // Ordem correta dos itens

    // Prefabs para as letras
    public Objects prefabL;
    public Objects prefabO;
    public Objects prefabV;
    public Objects prefabE;
    public Objects prefabA;
    public Objects prefabC;

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

        reward.SetActive(false); // Desativa a chave até que a missão seja completa

        // Inicializa a ordem correta dos itens
        correctOrder = new Objects[12];
        correctOrder[0] = prefabL; // Slot 0: Prefab(L)
        correctOrder[1] = prefabO; // Slot 1: Prefab(O)
        correctOrder[2] = prefabV; // Slot 2: Prefab(V)
        correctOrder[3] = prefabE; // Slot 3: Prefab(E)
        // Pulando quatro espaços (4 a 7)
        correctOrder[8] = prefabL; // Slot 8: Prefab(L)
        correctOrder[9] = prefabA; // Slot 9: Prefab(A)
        correctOrder[10] = prefabC; // Slot 10: Prefab(C)
        correctOrder[11] = prefabE; // Slot 11: Prefab(E)
    }

    private void Update()
    {
        if (!inventoryPanel.activeInHierarchy) return;

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

        CheckMissionCompletion();
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
            GameObject itemPrefab = slots[index].objectPrefab; 
            GameObject droppedItem = Instantiate(itemPrefab, position, Quaternion.identity);
            droppedItem.tag = "Object"; 
            droppedItem.AddComponent<ObjectType>().objectType = slots[index]; 
            slots[index] = null;
            slotImage[index].sprite = null;
            slotImage[index].color = Color.clear;
        }
    }

    private void CheckMissionCompletion()
    {
        for (int i = 0; i < correctOrder.Length; i++)
        {
            if (i >= 4 && i < 8) // Ignora os slots 4 a 7
                continue;

            if (slots[i] == null || slots[i] != correctOrder[i])
            {
                return; // Missão não completada
            }
        }
        
        reward.SetActive(true); // Ativa a recompensa
    }
}
