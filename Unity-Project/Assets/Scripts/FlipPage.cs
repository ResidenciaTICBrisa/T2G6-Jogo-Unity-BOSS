using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPage : MonoBehaviour
{
	private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (mAnimator != null) 
		{
			if (Input.GetKeyDown(KeyCode.F)) mAnimator.SetTrigger("frontFlip");
			if (Input.GetKeyDown(KeyCode.B)) mAnimator.SetTrigger("backFlip");
		}
    }
}
