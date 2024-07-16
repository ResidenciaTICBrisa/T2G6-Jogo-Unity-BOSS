using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    public GameObject inventoryPanel;
    bool invActive = false;

    void Start()
    {
        // Certifique-se de que o inventário esteja fechado no início
        CloseInventory();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
        if(invActive)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void ToggleInventory()
    {
        if(invActive) CloseInventory();
        else OpenInventory();
    }

    public void OpenInventory()
    {
        invActive = true;
        inventoryPanel.SetActive(true);
    }

    public void CloseInventory()
    {
        invActive = false;
        inventoryPanel.SetActive(false);
    }

    // Métodos para serem chamados pelos botões
    public void OnOpenInventoryButtonClicked()
    {
        OpenInventory();
    }

    public void OnCloseInventoryButtonClicked()
    {
        CloseInventory();
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class InterfaceController : MonoBehaviour
// {
//     public GameObject inventoryPanel;
//     bool invActive = false;

//     void Start()
//     {
        
//     }
//     void Update()
//     {
//         if(Input.GetKeyDown(KeyCode.Tab))
//         {
//             ToggleInventory();
//         }
//         if(invActive)
//         {
//             Cursor.lockState = CursorLockMode.None;
//         }
//     }

//     private void ToggleInventory()
//     {
//         if(invActive) CloseInventory();
//         else OpenInventory();
//     }

//     public void OpenInventory()
//     {
//         invActive = true;
//         inventoryPanel.SetActive(true);
//     }

//     public void CloseInventory()
//     {
//         invActive = false;
//         inventoryPanel.SetActive(false);
//     }
// }
