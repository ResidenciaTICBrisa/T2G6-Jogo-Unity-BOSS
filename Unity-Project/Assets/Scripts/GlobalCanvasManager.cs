using UnityEngine;

public class GlobalCanvasManager : MonoBehaviour
{
    public static GlobalCanvasManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }
}
