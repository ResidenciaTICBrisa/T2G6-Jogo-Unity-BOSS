using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Porta : MonoBehaviour
{
    [SerializeField]
    private string nextScene;
    public GameObject sceneChangePanel;
    public string text;
    public Text panelText;
    public Button button;

    private void OnTriggerEnter2D(Collider2D collision){
        sceneChangePanel.SetActive(true);
        panelText.text = text;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(NextScene);

    }
    public void NextScene(){
        SceneManager.LoadScene(nextScene);
    }

    public void DontChangeScene()
    {
        sceneChangePanel.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sceneChangePanel.SetActive(false);
    }

}
