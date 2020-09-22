using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float m_timeLeftBeforeSpawn = 0;
    private SpawnPoint[] m_spawnPoints;
    public float m_spawnRate = 1;
    public GameObject m_enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnPoints = FindObjectsOfType<SpawnPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpawn();
    }

    private void UpdateSpawn()
    {
        m_timeLeftBeforeSpawn -= Time.deltaTime;
        if (m_timeLeftBeforeSpawn <= 0)
        {
            SpawnEnemy();
            m_timeLeftBeforeSpawn = m_spawnRate;
        }
    }

    private void SpawnEnemy()
    {
        int spawnPointsCount = m_spawnPoints.Length;
        int randomSpawnPointIndex = Random.Range(0, spawnPointsCount);
        SpawnPoint currentSpawnPoint = m_spawnPoints[randomSpawnPointIndex];

        Instantiate(m_enemyPrefab, currentSpawnPoint.transform.position, Quaternion.identity);
    }
}
