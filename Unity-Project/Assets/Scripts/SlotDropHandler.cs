using UnityEngine;
using UnityEngine.EventSystems;

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
