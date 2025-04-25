using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

namespace PartIV
{
    public class EnemyMovement : MonoBehaviour
    {
        public Vector3 startPosition;       // Posição mais a esquerda do inimigo
        public Vector3 endPosition;         // Posição mais a direita do inimigo
        public float speed = 1;             // Velocidade de movimento do inimigo

        private int direction = 1;          // Direção de movimento do inimigo (1 = direita, -1 = esquerda)

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position += Vector3.right * speed * direction;            // Inimigo se move com a direção e velocidade indicada

            if (Vector3.Distance(transform.position, startPosition) < 0.1f)     // Se o inimigo estiver na posição inicial
            {
                direction = 1;          // Direção = direita
            }

            if (Vector3.Distance(transform.position, endPosition) < 0.1f)       // Se o inimigo estiver na posição final
            {
                direction = -1;         // Direção = esquerda
            }
        }
    }
}