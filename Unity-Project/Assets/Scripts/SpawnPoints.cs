using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine.SceneManagement;
using UnityEngine;
using static SpawnPoints;

public class SpawnPoints : MonoBehaviour
{

    public struct cityMap
    {
        public Vector3 X { get; set; }
        public cityMap(Vector3 x)
        {
            X = x;
        }
    }
    public enum currentPosition {none, library, house, shop}

    public currentPosition currentSpawn = currentPosition.none;

    public GameObject player;

    cityMap[] points = new cityMap[3];

    // Start is called before the first frame update
    void Start()
    {
        points[2] = new cityMap(new Vector3(10.15f,-4.6f,0));
        points[1] = new cityMap(new Vector3(-11.48f, -9.65f, 0));
        points[0] = new cityMap(new Vector3(23.5f, -14.48f, 0));
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Spawn");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("OnEnable chamado");
    }

    // Desinscrevendo-se do evento de carregamento de cenas
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Método chamado quando uma nova cena é carregada
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (currentSpawn == currentPosition.library)
        {
            player.transform.position = points[0].X;
            currentSpawn = currentPosition.none;
        }
        else if (currentSpawn == currentPosition.house)
        {
            player.transform.position = points[1].X;
            currentSpawn = currentPosition.none;
        }
        else if (currentSpawn == currentPosition.shop)
        {
            player.transform.position = points[2].X;
            currentSpawn = currentPosition.none;
        }

        Scene cena = SceneManager.GetActiveScene();
        if (cena.name == "Library")
        {
            currentSpawn = currentPosition.library;
        }
    }
}
