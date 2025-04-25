using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartIII
{
    public class GameGoalController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("Você venceu!");      // Escreve essa mensagem no console quando o player tocar na moeda
        }
    }
}