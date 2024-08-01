using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCarousel : MonoBehaviour
{
    public GameObject diaryPrefab;
    public Transform contentPanel;
    public Button nextButton;
    public Button prevButton;
    private int currentDiaryIndex = 0;

    void Start()
    {
        nextButton.onClick.AddListener(ShowNextDiary);
        prevButton.onClick.AddListener(ShowPreviousDiary);
        UpdateCarousel();
    }

    public void ShowNextDiary()
    {
        if (Inventory.instance.diaries.Count == 0) return;

        currentDiaryIndex = (currentDiaryIndex + 1) % Inventory.instance.diaries.Count;
        UpdateCarousel();
    }

    public void ShowPreviousDiary()
    {
        if (Inventory.instance.diaries.Count == 0) return;

        currentDiaryIndex = (currentDiaryIndex - 1 + Inventory.instance.diaries.Count) % Inventory.instance.diaries.Count;
        UpdateCarousel();
    }

    void UpdateCarousel()
    {
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        if (Inventory.instance.diaries.Count > 0)
        {
            GameObject diary = Instantiate(diaryPrefab, contentPanel);
            diary.name = Inventory.instance.diaries[currentDiaryIndex];

            InventoryDiary inventoryDiary = diary.GetComponent<InventoryDiary>();
            inventoryDiary.diaryName = Inventory.instance.diaries[currentDiaryIndex];
        }
    }
}
