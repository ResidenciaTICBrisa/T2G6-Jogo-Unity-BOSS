using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopScripts : MonoBehaviour
{
    public void Store() {
        SceneManager.LoadScene("Store");
    }
}