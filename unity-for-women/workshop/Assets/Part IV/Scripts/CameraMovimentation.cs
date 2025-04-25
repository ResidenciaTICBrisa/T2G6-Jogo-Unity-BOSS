using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartIV
{
    public class CameraMovimentation : MonoBehaviour
    {
        public GameObject player;           // Referência ao jogador

        public float minCameraPosition;     // Valor mínimo da posição da câmera em X
        public float maxCameraPosition;     // Valor máximo da posição da câmera em X

        // Start is called before the first frame update
        void Start()
        {
         
        }

        // Update is called once per frame
        void Update()
        {
            if(player.transform.position.x >= minCameraPosition && player.transform.position.x <= maxCameraPosition)        // Entra na condição se o jogador estiver dentro dos limites da câmera
            {
                transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);      // Atualiza a posição da câmera para seguir o jogador no eixo X
            }
        }
    }
}