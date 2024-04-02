using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManScript : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    private float timePassed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        rb.velocity = new Vector2(speed, 0);
        anim.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = transform.position.x - currentPoint.position.x;
        if(distance < 0) distance = distance * -1;

        if(distance < 1 && currentPoint == pointB.transform){
            currentPoint = pointA.transform;
            transform.localRotation *= Quaternion.Euler(0, 180, 0);
            rb.velocity = new Vector2(-speed, 0);
        } else if(distance < 1 && currentPoint == pointA.transform){
            currentPoint = pointB.transform;
            transform.localRotation *= Quaternion.Euler(0, 180, 0);
            rb.velocity = new Vector2(speed, 0);
        }

        timePassed += Time.deltaTime;
        if(timePassed > 10f)
        {
            timePassed = 0f;
            StartCoroutine("Pause");
        }
    }

    IEnumerator Pause()
    {
        //Put your code before waiting here
        anim.SetBool("isWalking", false);
        Vector2 backupSpeed = rb.velocity;
        rb.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(4);
        anim.SetBool("isWalking", true);
        rb.velocity = backupSpeed;
    }
}
