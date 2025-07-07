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

    [SerializeField]
    private int maxIndex;
    [SerializeField]
    private int currentIndex = 0;
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

    private void Update()
    {
        if (maxIndex == 0)
        {
            buttonF.interactable = false;
            buttonB.interactable = false;
            return;
        } else
        {
            buttonF.interactable = true;
        }
        if (currentIndex == 0)
        {
            buttonB.interactable = false;
        } else if (currentIndex == maxIndex) { 
            buttonF.interactable = false;
        } else
        {
            buttonF.interactable = true;
            buttonB.interactable = true;
        }
    }

    public void FrontFlip ()
    {
        mAnimator.SetTrigger("fontFlip");
        currentIndex++;
        Debug.Log("CLick " + mAnimator.name);
    }

    public void BackFlip ()
    {
        mAnimator.SetTrigger("backFlip");
        currentIndex--;
        Debug.Log("CLick");
    }

    public void CloseScene(string sceneNameToUnload)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == sceneNameToUnload)
            {
                // Descarrega a cena de forma ass�ncrona
                SceneManager.UnloadSceneAsync(sceneNameToUnload);
                Debug.Log("Unloaded scene: " + sceneNameToUnload);
                return;
            }
        }
    }
}
