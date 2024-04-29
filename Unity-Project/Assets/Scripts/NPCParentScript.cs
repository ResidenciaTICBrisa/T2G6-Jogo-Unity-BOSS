using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCParentScript : MonoBehaviour
{
    public bool isTalkable = false;

    public IEnumerator Talking()
    {
        isTalkable = true;
        yield return new WaitForSeconds(0.3f);
        isTalkable = false;
    }
}
