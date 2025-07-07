using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PartIV
{
    public class PlayerMovimentation : MonoBehaviour
    {
        public float playerHealth = 100;    // Vida inicial do jogador
        public Text playerHealtText;        // Referência ao texto de vida da UI
        public float maxSpeed = 1f;         // Velocidade máxima horizontal
        public float jumpSpeed = 15f;       // Aceleração do pulo
        public Rigidbody2D myrigidbody;     // Componente Rigidbody2D
        

        private int multiJump = 0;          // Quantidade de pulos que o jogador já fez
        public int maxJump = 3;             // Quantidade máxima de pulos

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



            if (Input.GetButtonDown("Jump") && multiJump < maxJump)   // Se barra de espaço foi apertada e ainda houverem pulos disponíveis
            {
                multiJump += 1;     // Aumenta a quantidade de pulos já realizados
                Debug.Log("Jump"); // Quando pular escreve "Jump" no Debug Log

                myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, jumpSpeed); // velociade do rigidbody = velocidade vertical*velocidade pulo 

            }
        }

      
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.contacts[0].normal == Vector2.up)        // Colisão com o chão
            {
                multiJump = 0;      // Reseta a quantidade de pulos do jogador
            }

            if (other.gameObject.CompareTag("Enemy"))           // Colisão com um inimigo
            {
                
                playerHealth -= 20;                                 // Reduz a vida do jogador
                Debug.Log("OUCH " + playerHealth);                  // Mostra a vida no console
                playerHealtText.text = ("HP: " + playerHealth);     // Atualiza o texto da UI

            }
        }
    }
}