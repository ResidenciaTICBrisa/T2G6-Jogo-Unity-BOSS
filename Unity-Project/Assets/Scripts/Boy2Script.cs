using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Boy2Script : NPCScript
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float leftPatrolX, rightPatrolX, upPatrolY, bottomPatrolY;
    [SerializeField] private int facingDirection = 1;
    [SerializeField] private float minPauseTime, maxPauseTime;
    [SerializeField] private float minWalkTime, maxWalkTime;
    [SerializeField] private Animator anim;

    private float randomTime, timer;
    private bool isFlipping;
    private bool isWalking = true;
    private bool isWalkingUp;
    private bool isWalkingDown;
    private bool isWalkingLeft;
    private bool isWalkingRight;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = "";
        sound = GetComponent<AudioSource>();
        randomTime = Random.Range(minWalkTime, maxWalkTime);
        anim.SetBool("isWalkingLeft", isWalking ? true : false);
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

        if(playerIsClose)
        {
            rb.velocity = new Vector2(0, 0);
            isWalking = false;
            anim.SetBool("isWalkingLeft", isWalking ? true : false);
            return;
        }

        timer += Time.deltaTime;

        if(timer >= randomTime)
        {
            StateChange();
        }

        if(!isFlipping && (transform.position.x > rightPatrolX || transform.position.x < leftPatrolX))
        {
            StartCoroutine(FlipX());
        }
        if((transform.position.y > upPatrolY || transform.position.y < bottomPatrolY))
        {
            //FlipY();
        }

        if (isWalking)
        {
            rb.velocity = Vector2.right * facingDirection * speed;
        }
    }

    IEnumerator FlipX()
    {
        isFlipping = true;
        transform.Rotate(0,180,0);
        facingDirection *= -1;
        yield return new WaitForSeconds(0.5f);
        isFlipping = false;
    }

    void FlipY()
    {
        transform.Rotate(180,0,0);
    }

    void StateChange()
    {
        isWalking = !isWalking;
        anim.SetBool("isWalkingLeft", isWalking ? true : false);
        if (!isWalking) { rb.velocity = new Vector2(0, 0); }
        else { rb.velocity = Vector2.right * facingDirection * speed; }
        randomTime = isWalking ? Random.Range(minWalkTime, maxWalkTime) : Random.Range(minPauseTime, maxPauseTime);
        timer = 0;
    }

    public new void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            RemoveText();
            if (isWalking)
            {
                StateChange();
            }
        }
    }
}
