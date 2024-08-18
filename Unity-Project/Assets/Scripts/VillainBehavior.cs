using UnityEngine;

public class VillainBehavior : MonoBehaviour
{
    public Transform player; // Referência à jogadora
    public GameObject projectilePrefab; // Prefab do projétil
    public float speed = 2f; // Velocidade de movimento do vilão
    public float minAttackInterval = 1f; // Intervalo mínimo para lançar um projétil
    public float maxAttackInterval = 3f; // Intervalo máximo para lançar um projétil
    public float projectileSpeed = 10f; // Velocidade do projétil

    private float timeToNextAttack; // Tempo até o próximo ataque

    void Start()
    {
        SetNextAttackTime(); // Define o tempo inicial para o próximo ataque
    }

    void Update()
    {
        MoveTowardsPlayer(); // Faz o vilão seguir a jogadora
        HandleAttack(); // Gerencia o ataque do vilão
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void HandleAttack()
    {
        timeToNextAttack -= Time.deltaTime;

        if (timeToNextAttack <= 0f)
        {
            LaunchProjectile();
            SetNextAttackTime(); // Reseta o tempo para o próximo ataque
        }
    }

    void SetNextAttackTime()
    {
        // Define um tempo aleatório para o próximo ataque
        timeToNextAttack = Random.Range(minAttackInterval, maxAttackInterval);
    }

    void LaunchProjectile()
    {
        if (projectilePrefab != null && player != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Vector2 direction = (player.position - transform.position).normalized;
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * projectileSpeed;
        }
    }
}
