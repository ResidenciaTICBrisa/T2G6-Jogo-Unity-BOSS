using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryDiary : MonoBehaviour
{
    public string diaryName;

    public void OpenDiary()
    {
        SceneManager.LoadScene(diaryName, LoadSceneMode.Additive);
    }
}
