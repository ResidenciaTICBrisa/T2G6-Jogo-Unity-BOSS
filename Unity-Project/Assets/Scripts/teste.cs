using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testeController : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] Transform item;
    [SerializeField] Transform itemRef;

    public bool HaveItem()
    {
        return this.item != null;
    }

    public Transform GetItem()
    {
        Transform itemToReturn = this.item;
        this.item = null;

        return itemToReturn;
    }

    public void SetItem(Transform _item)
    {
        this.item = _item;
    }

    public Transform GetItemRef()
    {
        return this.itemRef;
    }
}