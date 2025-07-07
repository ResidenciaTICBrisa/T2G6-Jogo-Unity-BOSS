using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartII
{
    public class PlayerMovimentation : MonoBehaviour
    {
        public float maxSpeed = 1f;         // Velocidade máxima horizontal
        public float jumpSpeed = 0.5f;      // Aceleração do pulo
        public Rigidbody2D myrigidbody;     // Componente Rigidbody2D

        private bool isJumping = false;     // Diz se o jogador já está 

        // Start is called before the first frame update
        void Start()
        {
            myrigidbody = GetComponent<Rigidbody2D>();  // Inicializa a variável ao rodar o jogo
        }

        // Update is called once per frame
        void Update()
        {

            var inputX = Input.GetAxis("Horizontal");
            // inputX = -1 se o player apertar o botão para mover para a esquerda
            //        =  1 para a direita
            //        =  0 se nenhum dos dois estiver sendo apertado


            myrigidbody.velocity = new Vector2(inputX * maxSpeed, myrigidbody.velocity.y);
            // Atualiza a velocidade horizontal todo frame



            if (Input.GetButtonDown("Jump") && !isJumping) 
            {

                Debug.Log("Jump"); // Quando pular escreve "Jump" no Debug Log

                myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, jumpSpeed); // atualiza a velocidade vertical do jogador para fazê-lo pular

                isJumping = true;  // Impede que o player pule denovo
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            isJumping = false;  // Permite que o player pule denovo
        }
    }
}