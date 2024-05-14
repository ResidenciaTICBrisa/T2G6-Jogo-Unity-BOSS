using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerController : MonoBehaviour
{
    [Header("config")]
    [SerializeField] Transform item;

    public bool HaveItem()
    {
        return this.item != null;
    
    }
    public Transform GetItem()
    {
        Transform ItemToReturn = this.item;
        this.item = null;

        return ItemToReturn;
    }
    
    public void SetItem(Transform _item)
    {
        this.item = _item;
    }
  


}
