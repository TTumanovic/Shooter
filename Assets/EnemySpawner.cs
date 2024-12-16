using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 5f;

    private void Start()
    {
        //O
        InvokeRepeating(nameof(SpawnEnemy), spawnInterval, spawnInterval);
    }

    private void SpawnEnemy()
    {
        //D
        if (spawnPoints.Length == 0) return;

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
           
            enemyScript.maxMoveSpeed = Random.Range(2f, 7f); 
        }
    }
}
