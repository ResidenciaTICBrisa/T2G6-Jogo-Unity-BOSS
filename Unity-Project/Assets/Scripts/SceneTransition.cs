using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField]
    private string nextScene;
    public GameObject sceneChangePanel;
    public string text;
    public Text panelText;
    public Button button;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision){
        sceneChangePanel.SetActive(true);
        panelText.text = text;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(NextScene);
        anim = GameObject.FindGameObjectWithTag("Scene").GetComponent<Animator>();

    }
    public void NextScene(){
        StartCoroutine(Fade());
        sceneChangePanel.SetActive(false);
    }

    public IEnumerator Fade()
    {
        anim.SetTrigger("Exit");
        Debug.Log("FadeOut");
        yield return new WaitForSeconds(2);
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
