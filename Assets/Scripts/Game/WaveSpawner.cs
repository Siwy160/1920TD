using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float waveInternalSec = 10f;
    [SerializeField] private Transform spawnPoint;
    private float countdown = 2;
    private int waveNumber = 1;
    private float enemySpawnInterval = 0.5f;

    public EnemyData enemyData;

    public Text waveCountdownText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        countdown -= Time.deltaTime;
        waveCountdownText.text = ((int)countdown + 1).ToString();
        if (countdown <= 0f)
        {
            countdown = waveInternalSec;
            StartCoroutine(SpawnWave());
        }
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < GetMonstersInCurrentWave(); i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(enemySpawnInterval);
        }
        waveNumber++;
    }

    private void SpawnEnemy()
    {
        enemyPrefab.GetComponent<Enemy>().enemyData = enemyData;
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

    }

    private int GetMonstersInCurrentWave()
    {
        return waveNumber;
    }
}
