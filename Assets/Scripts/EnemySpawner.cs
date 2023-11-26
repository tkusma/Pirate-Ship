using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] enemy;

    private float clock, spawnTime;
    void Start()
    {
        spawnTime = PlayerPrefs.GetFloat("spawnTime", 5);
        SpawnEnemy();
    }

    void Update()
    {
        clock -= Time.deltaTime;
        if (clock <= 0)
            SpawnEnemy();
    }

    void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemy.Length);
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy[enemyIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
        clock = spawnTime;
    }
}
