using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace VGS
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<EnemyType> enemyTypes;
        [SerializeField] private int maxEnemies = 10;
        [SerializeField] private float spawnInternal = 2f;

        private List<SplineContainer> splines;
        private EnemyFactory enemyFactory;
        private float spawnTimer;
        private int enemiesSpawned;

        private void OnValidate() {
            splines = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
        }

        private void Start() => enemyFactory = new EnemyFactory();

        private void Update()
        {
            spawnTimer += Time.deltaTime;

            if (enemiesSpawned < maxEnemies && spawnTimer >= spawnInternal)
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }
        }

        private void SpawnEnemy()
        {
            EnemyType enemyType = enemyTypes[Random.Range(0, enemyTypes.Count)];
            SplineContainer spline = splines[Random.Range(0, splines.Count)];

            enemyFactory.CreateEnemy(enemyType, spline);
            enemiesSpawned++;
        }
    }
}
