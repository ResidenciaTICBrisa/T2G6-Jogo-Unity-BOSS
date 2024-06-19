using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "Inventory Objects/Create New")]
public class Objects : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
}
