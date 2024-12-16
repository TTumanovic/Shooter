using UnityEngine;

public class Enemy : Character
{
    public float maxMoveSpeed = 5f; 
    public float moveSpeed;
    public int damage = 10;
    public int scoreValue = 10;

    private Transform player;

    protected override void Start()
    {
        //L
        //Inkap
        base.Start();

        currentHealth = Random.Range(1, maxHealth + 1);

        moveSpeed = Random.Range(1f, maxMoveSpeed);

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    protected override void Die()
    {
        //O
        //S
        ScoreManager.Instance.AddScore(scoreValue);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //I
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player?.TakeDamage(damage);
        }
    }
}
