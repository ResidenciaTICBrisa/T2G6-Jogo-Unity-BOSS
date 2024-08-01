using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject DiaryInventory; 
    public Button openInventoryButton; 
    public Button closeInventoryButton; 

    void Awake()
    {
        if (FindObjectsOfType<InventoryManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        openInventoryButton.onClick.AddListener(OpenInventory);
        closeInventoryButton.onClick.AddListener(CloseInventory);
        DiaryInventory.SetActive(false); 
    }

    public void OpenInventory()
    {
        Debug.Log("OpenInventory called");
        DiaryInventory.SetActive(true);
    }

    public void CloseInventory()
    {
        Debug.Log("CloseInventory called");
        DiaryInventory.SetActive(false);
    }

}
