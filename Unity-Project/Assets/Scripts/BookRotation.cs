using UnityEngine;

public class BookRotation : MonoBehaviour
{
    public float rotationSpeed = 360f; // Velocidade de rotação em graus por segundo

    private bool isRotating = false;


    void Update()
    {
        if (isRotating)
        {
            // Rotaciona o livro ao redor do eixo Z
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
    
    void OnCollisionEnter2D(Collision2D Other)
    {
        if (isRotating)Destroy(gameObject);
    }


    public void StartRotation()
    {
        isRotating = true;
    }

    public void StopRotation()
    {
        isRotating = false;
    }
}
