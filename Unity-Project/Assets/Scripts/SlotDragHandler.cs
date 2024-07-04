using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

            RectTransform rectTransform = GetComponent<RectTransform>();
            Rect inventoryRect = inventoryController.inventoryPanel.GetComponent<RectTransform>().rect;

            if (!RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition))
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
                worldPosition.z = 0; // Certifique-se de que o objeto seja colocado no plano z correto
                inventoryController.DropItem(slotIndex, worldPosition);
            }
        }
        itemImage.color = originalColor;
    }
}
