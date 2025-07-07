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
    public enum currentPosition {none, library, house, shop, houseBed, grove}

    public currentPosition currentSpawn = currentPosition.none;

    public GameObject player;

    public GameObject fade;

    public GameObject buttonsCanvas;
    public Animator anim;
    AudioSource[] sounds;
    public int musicStatus = 0;

    cityMap[] points = new cityMap[5];

    // Start is called before the first frame update
    void Start()
    {
        points[4] = new cityMap(new Vector3(0, -15f, 0));
        points[3] = new cityMap(new Vector3(22.08f, 1.58f, 0));
        points[2] = new cityMap(new Vector3(10.15f,-4.6f,0));
        points[1] = new cityMap(new Vector3(-11.48f, -9.65f, 0));
        points[0] = new cityMap(new Vector3(23.5f, -14.48f, 0));
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Spawn");
        sounds = GetComponents<AudioSource>();
        Scene cena = SceneManager.GetActiveScene();
        if (cena.name == "MainMenu")
        {
            sounds[0].Play();
            currentSpawn = currentPosition.houseBed;
        }

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void DisableCanvas()
    {
        int countLoaded = SceneManager.sceneCount;
        if(buttonsCanvas != null)
        {
            Debug.Log(countLoaded);
            buttonsCanvas.SetActive(countLoaded <= 1);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("OnEnable chamado");
    }

    // Desinscrevendo-se do evento de carregamento de cenas
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    // M�todo chamado quando uma nova cena � carregada
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        buttonsCanvas = GameObject.FindGameObjectWithTag("ButtonCanvas");
        DisableCanvas();
        Scene cena = SceneManager.GetActiveScene();
        // Checagem de cena para escolher trilha sonora
        if (cena.name == "MainMenu")
        {
            sounds[0].Play();
            musicStatus = 0;
        } else if(cena.name == "CityMap" && musicStatus == 0)
        {
            sounds[0].Stop();
            sounds[1].Play();
            musicStatus = 1;
        } else if (cena.name == "Library")
        {
            sounds[1].Stop();
            musicStatus = 0;
        }

        int countLoaded = SceneManager.sceneCount;
        if (countLoaded > 1)
        {
            for (int i = 0; i < countLoaded; i++)
            {
                Scene isFlip = SceneManager.GetSceneAt(i);
                if(isFlip.name == "BookFlip")
                {
                    return;
                }
            }
        }

        // Ativacao da vinheta quando entra em cenas diferentes do menu
        if (cena.name == "MainMenu")
        {
            fade.SetActive(false);
        } else
        {
            fade.SetActive(true);
            anim.SetTrigger("Enter");
        }

        // De acordo com o spawnpoint salvo abaixo, mude a posicao do player para a correspondente
        player = GameObject.FindGameObjectWithTag("Player");
        if (currentSpawn == currentPosition.library)
        {
            player.transform.position = points[0].X;
        }
        else if (currentSpawn == currentPosition.house)
        {
            player.transform.position = points[1].X;
        }
        else if (currentSpawn == currentPosition.shop)
        {
            player.transform.position = points[2].X;
        } else if (currentSpawn == currentPosition.houseBed)
        {
            player.transform.position = points[3].X;
        } else if (currentSpawn == currentPosition.grove)
        {
            player.transform.position = points[4].X;
        }

        currentSpawn = currentPosition.none;

        // De acordo com qual cena esta agora, como todas elas levam apenas para o citymap, salve o proximo spawnpoint
        if (cena.name == "Library")
        {
            currentSpawn = currentPosition.library;
        } else if (cena.name == "Shop")
        {
            currentSpawn = currentPosition.shop;
        } else if (cena.name == "SofiaHouse")
        {
            currentSpawn = currentPosition.house;
        } else if (cena.name == "MainMenu")
        {
            currentSpawn = currentPosition.houseBed;
        } else if (cena.name == "Grove")
        {
            currentSpawn = currentPosition.grove;
        }
    }

    void OnSceneUnloaded(Scene scene)
    {
        StartCoroutine(ReenableCanvasAfterSceneUnloaded());
    }

    IEnumerator ReenableCanvasAfterSceneUnloaded()
    {
        yield return null; // Espera um frame para garantir que a cena foi descarregada
        if (SceneManager.sceneCount <= 1 && buttonsCanvas != null)
        {
            buttonsCanvas.SetActive(true);
        }
    }
}
