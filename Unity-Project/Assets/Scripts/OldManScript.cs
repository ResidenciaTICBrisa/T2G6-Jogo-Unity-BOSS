using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OldManScript : NPCScript
{
    // Point A and B are game objects that point out the path of the NPC
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    AudioSource sound;
    // Current Point refers to the point that the NPC is going to
    private Transform currentPoint;
    public float speed;
    private float timePassed = 0f;
    private bool stopEverything = false;
    Vector2 backupSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        // Start the movement by pointing to B
        currentPoint = pointB.transform;
        rb.velocity = new Vector2(speed, 0);
        // Start the animation of walking
        anim.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
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
        if (stopEverything)
        {
            return;
        }
        // Get the current distance of the NPC to the point
        float distance = transform.position.x - currentPoint.position.x;
        // If distance less than zero, make it positive
        if(distance < 0) distance = distance * -1;

        // If the distance of the NPC to the point is less than one, go to the other point
        if(distance < 1 && currentPoint == pointB.transform){
            currentPoint = pointA.transform;
            // Rotate the sprite of the NPC
            transform.localRotation *= Quaternion.Euler(0, 180, 0);
            rb.velocity = new Vector2(-speed, 0);
        } else if(distance < 1 && currentPoint == pointA.transform){
            currentPoint = pointB.transform;
            transform.localRotation *= Quaternion.Euler(0, 180, 0);
            rb.velocity = new Vector2(speed, 0);
        }

        // This part of the code makes the NPC stop walking for a breaf moment (every 8 seconds)
        timePassed += Time.deltaTime;
        if(timePassed > 8f)
        {
            timePassed = 0f;
            StartCoroutine("Pause");
        }
    }

    IEnumerator Pause()
    {
        // Make the animation of walk stop
        anim.SetBool("isWalking", false);
        backupSpeed = rb.velocity;
        rb.velocity = new Vector2(0, 0);
        // Stop the code for 4 seconds
        yield return new WaitForSeconds(4);
        if (!stopEverything)
        {
            anim.SetBool("isWalking", true);
            rb.velocity = backupSpeed;
        }
    }

    public new void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            stopEverything = true;
            anim.SetBool("isWalking", false);
            backupSpeed = rb.velocity;
            rb.velocity = new Vector2(0,0);
        }
    }

    public new void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            RemoveText();
            stopEverything = false;
            anim.SetBool("isWalking", true);
            if(currentPoint == pointB.transform)
            {
                rb.velocity = new Vector2(speed, 0);
            } else
            {
                rb.velocity = new Vector2(-speed, 0);
            }

        }
    }
}
