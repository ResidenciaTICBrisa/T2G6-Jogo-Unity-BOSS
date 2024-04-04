using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManScript : MonoBehaviour
{
    // Point A and B are game objects that point out the path of the NPC
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    // Current Point refers to the point that the NPC is going to
    private Transform currentPoint;
    public float speed;
    private float timePassed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // Start the movement by pointing to B
        currentPoint = pointB.transform;
        rb.velocity = new Vector2(speed, 0);
        // Start the animation of walking
        anim.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
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
        Vector2 backupSpeed = rb.velocity;
        rb.velocity = new Vector2(0, 0);
        // Stop the code for 4 seconds
        yield return new WaitForSeconds(4);
        anim.SetBool("isWalking", true);
        rb.velocity = backupSpeed;
    }
}
