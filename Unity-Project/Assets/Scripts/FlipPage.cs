using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlipPage : MonoBehaviour
{
	private Animator mAnimator;
    public Button buttonF;
    public Button buttonB;
    // Start is called before the first frame update
    void OnEnable()
    {
        Button [] restart = GameObject.Find("CanvasButtons").GetComponentsInChildren<Button>();
        buttonF = restart[0];
        buttonB = restart[1];
        mAnimator = GetComponent<Animator>();
        buttonF.onClick.RemoveAllListeners();
        buttonB.onClick.RemoveAllListeners();
        buttonF.onClick.AddListener(FrontFlip);
        buttonB.onClick.AddListener(BackFlip);
    }

    public void FrontFlip ()
    {
        mAnimator.SetTrigger("fontFlip");
        Debug.Log("CLick " + mAnimator.name);
    }

    public void BackFlip ()
    {
        mAnimator.SetTrigger("backFlip");
        Debug.Log("CLick");
    }

    public void CloseScene(string sceneNameToUnload)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == sceneNameToUnload)
            {
                // Descarrega a cena de forma assíncrona
                SceneManager.UnloadSceneAsync(sceneNameToUnload);
                Debug.Log("Unloaded scene: " + sceneNameToUnload);
                return;
            }
        }
    }
}
