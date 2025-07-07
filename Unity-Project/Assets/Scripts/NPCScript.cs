using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPCScript : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] public GameObject dialoguePanel;
    [SerializeField] public Text dialogueText;
    [SerializeField] public Text nameText;
    [SerializeField] public GameObject photoPanel;

    [Header("NPC Data")]
    [SerializeField] public string[] dialogues;
    [SerializeField] public string npcName;
    [SerializeField] public Sprite photo;

    [Header("Audio")]
    [SerializeField] public AudioSource audioSource;

    [Header("Settings")]
    [SerializeField] public float wordSpeed = 0.05f;

    public int dialogueIndex = 0;
    public bool playerIsClose = false;
    public bool isTalkable = false;
    public bool skipTalk = false;

    private void Awake()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        dialogueText.text = string.Empty;
    }

    private void Update()
    {
        HandleDialogueInput();
    }

    protected virtual void HandleDialogueInput()
    {
        if ((Input.GetKeyDown(KeyCode.E) || isTalkable) && playerIsClose)
        {
            isTalkable = false;
            if (!dialoguePanel.activeInHierarchy)
            {
                PlayAudio();
                ShowDialoguePanel();
                StartCoroutine(TypeDialogue());
            }
            else if (IsCurrentDialogueFullyDisplayed())
            {
                ShowNextDialogueLine();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && dialoguePanel.activeInHierarchy)
        {
            CloseDialogue();
        }
    }

    private void PlayAudio()
    {
        if (audioSource != null)
            audioSource.Play();
    }

    private void ShowDialoguePanel()
    {
        dialoguePanel.SetActive(true);
        nameText.text = npcName;
        if (photoPanel != null)
        {
            var image = photoPanel.GetComponent<Image>();
            if (image != null)
                image.overrideSprite = photo;
        }
    }

    private bool IsCurrentDialogueFullyDisplayed()
    {
        return dialogueText.text == dialogues[dialogueIndex];
    }

    private IEnumerator TypeDialogue()
    {
        dialogueText.text = string.Empty;
        foreach (char letter in dialogues[dialogueIndex])
        {
            if (skipTalk)
            {
                skipTalk = false;
                dialogueText.text = dialogues[dialogueIndex];
                break;
            }
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    private void ShowNextDialogueLine()
    {
        if (dialogueIndex < dialogues.Length - 1)
        {
            dialogueIndex++;
            StartCoroutine(TypeDialogue());
        }
        else
        {
            CloseDialogue();
        }
    }

    private void CloseDialogue()
    {
        dialogueText.text = string.Empty;
        dialogueIndex = 0;
        dialoguePanel.SetActive(false);
    }

    public void SkipCurrentDialogue()
    {
        if (!skipTalk)
            skipTalk = true;

        if (IsCurrentDialogueFullyDisplayed())
            ShowNextDialogueLine();
    }

    public void TriggerDialogue()
    {
        if (playerIsClose)
            isTalkable = true;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerIsClose = true;
        SetIndicatorActive(true);
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerIsClose = false;
        SetIndicatorActive(false);
        CloseDialogue();
    }

    private void SetIndicatorActive(bool isActive)
    {
        if (transform.childCount > 0)
            transform.GetChild(0).gameObject.SetActive(isActive);
    }
}
