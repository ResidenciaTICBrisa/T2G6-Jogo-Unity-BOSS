using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<string> diaries = new List<string>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddDiary(string diaryName)
    {
        if (!diaries.Contains(diaryName))
        {
            diaries.Add(diaryName);
        }
    }

    public static bool IsInitialized()
    {
        return instance != null;
    }
}
