using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
	public GameObject signBox;
	public Text signText;
	public string text;
	public bool playerInRange;
    protected bool isTalkable;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || isTalkable) && playerInRange)
        {
            isTalkable = false;
            if (signBox.activeInHierarchy)
				signBox.SetActive(false);
			else
			{
				signBox.SetActive(true);
				signText.text = text;
			}
		}
    }
    public void LetsTalk()
    {
        if (playerInRange) isTalkable = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			playerInRange = true;
			gameObject.transform.GetChild(0).gameObject.SetActive(true);
			if (text.Length <= 30) signText.fontSize = 150;
			else signText.fontSize = 100;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			playerInRange = false;
			signBox.SetActive(false);
			gameObject.transform.GetChild(0).gameObject.SetActive(false);
		}
	}
}
