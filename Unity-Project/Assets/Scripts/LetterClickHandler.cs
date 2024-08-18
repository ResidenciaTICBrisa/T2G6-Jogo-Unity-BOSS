using UnityEngine;

public class LetterClickHandler : MonoBehaviour
{
    private ShelfScript shelfScript;
    private int clickCount = 0;

    private void Start()
    {
        // Referência ao ShelfScript
        shelfScript = GetComponentInParent<ShelfScript>();
    }

    private void OnMouseDown()
    {
        clickCount++;

        // No segundo clique, coletar a letra e fazê-la sumir
        if (clickCount == 2)
        {
            if (shelfScript != null)
            {
                shelfScript.CollectLetter();
            }

            // Reseta o contador para prevenir cliques adicionais terem efeito
            clickCount = 0;
        }
    }
}
