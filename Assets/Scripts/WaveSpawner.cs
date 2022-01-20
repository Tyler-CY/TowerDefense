using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public bool ready;

    public static int EnemiesAlive = 0;

    public Wave[] waves;

    // The position of the spawn
    public Transform spawnPoint;

    // Time between spawning enemies
    public float timeBetweenWaves = 1.5f;

    // The duration before first enemys spawns
    private float countdown = 0.5f;

    private int waveIndex = 0;

    // All the text in the UI
    public Text WaveNumberText, TimerText, LevelText, MoneyText;

    public GameManager gameManager;

    private void Start()
    {
        ready = false;
        EnemiesAlive = 0;
        WaveNumberText.text = "Preparation Phase";
        TimerText.text = "0";
        LevelText.text = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUIText();

        if (!ready)
        {
            return;

        }


        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        // If it is time to spawn enemies, spawn enemies
        if (countdown <= 0f)
        {
            // Spawn enemies as a co routine
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves + waveIndex * 2;
            return;
        }

        // Decrease the time until enemy spawns;
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        

        

    }

    IEnumerator SpawnWave()
    {
        PlayerStats.wavesSurvived++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        PlayerStats.Money += 250;

        waveIndex++;
    }
        

    void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void UpdateUIText()
    {
        // Update the texts in the UI;
        WaveNumberText.text = "Wave " + (waveIndex + 1).ToString();
        MoneyText.text = "$" + PlayerStats.Money.ToString();
        TimerText.text = string.Format("{0:00.00}", countdown);
    }

    public void Ready()
    {
        ready = true;
    }
}
