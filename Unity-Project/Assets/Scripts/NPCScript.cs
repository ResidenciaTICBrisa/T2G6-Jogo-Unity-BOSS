using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NPCScript : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public Text nameText;
    public string[] dialogues;
    public string nameOfNPC;
    public Sprite photo;
    public GameObject photoPanel;
    public AudioSource sound;
    protected int index = 0;

    public float wordSpeed;
    public bool playerIsClose;
    protected bool isTalkable;
    protected bool skipTalk;
    protected bool lastLine = false;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = "";
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || isTalkable) && playerIsClose)
        {
            isTalkable = false;
            if (!dialoguePanel.activeInHierarchy)
            {
                if (sound)
                {
                    sound.Play();
                }
                dialoguePanel.SetActive(true);
                nameText.text = nameOfNPC;
                photoPanel.GetComponent<Image>().overrideSprite = photo;
                StartCoroutine(Typing());
            }
            else if (dialogueText.text == dialogues[index])
            {
                NextLine();
            }

        }
        if (Input.GetKeyDown(KeyCode.Q) && dialoguePanel.activeInHierarchy)
        {
            RemoveText();
        }
    }

    public void RemoveText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    protected IEnumerator Typing()
    {
        int count = 0;
        foreach(char letter in dialogues[index].ToCharArray())
        {
            if(skipTalk && count > 1)
            {
                skipTalk = false;
                dialogueText.text = dialogues[index];
                break;
            }
            skipTalk = false;
            dialogueText.text += letter;
            count++;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if(index < dialogues.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        } else
        {
            RemoveText();
        }
    }

    public void SkipTalk()
    {
        if (!skipTalk)
        {
            skipTalk = true;
        }
        if (dialogueText.text == dialogues[index])
        {
            NextLine();
        }
    }
    public void LetsTalk()
    {
        if(playerIsClose) isTalkable = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            RemoveText();
        }
    }
}
