using System.Collections;
using Game.Assets.Scripts.GamePlay;
using GamePlay;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    private WaveSpawnerListener _listener;
    private float enemySpawnInterval = 0.5f;
    public EnemyData enemyData;

    public WaveSpawnerListener Listener { set => _listener = value; }

    private IEnumerator SpawnWave(GamePlay.Data.WaveData waveData, EnemyDeathListener listener)
    {
        var enemies = waveData.Enemies;
        foreach (GameObject enemy in enemies)
        {
            SpawnEnemy(enemy, listener);
            yield return new WaitForSeconds(enemySpawnInterval);
        }

        if (_listener != null)
        {
            _listener.OnAllEnemieSpawned();
        }
    }

    private void SpawnEnemy(GameObject enemy, EnemyDeathListener listener)
    {
        GameObject enemyObject = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        Enemy enemyComponent = enemyObject.GetComponent<Enemy>();
        if (enemyComponent != null)
        {
            enemyComponent.Listener = listener;
        }
    }

    public void StartWave(GamePlay.Data.WaveData waveData, EnemyDeathListener listener)
    {
        StartCoroutine(SpawnWave(waveData, listener));
    }
}
