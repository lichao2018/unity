using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Boundary{
    public float xMin, xMax, zMin, zMax;
}

public class GameManager : MonoBehaviour {
    int waves = 3;
    int waveIndex = 0;
    public GameObject[] enemys;
    int waveKillCount;
    int enemyCount;

    public int baseEnemyNumber;
    public int baseEnemyLife;

    public Boundary boundary;
    public Vector3 spawnValue;

    private int coin;
    private bool gameOver;
    public Text coinText;
    public Text gameOverText;
    public Text restartText;

    private void Start()
    {
        coin = 0;
        UpdateCoin();
        gameOver = false;
        gameOverText.text = "";
        restartText.text = "";
        StartCoroutine(SpawnWaves());
    }

    void UpdateCoin()
    {
        coinText.text = "Coin:" + coin;
    }

    public void AddCoin(int value)
    {
        waveKillCount++;
        coin += value;
        UpdateCoin();
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "Game Over!";
        MenuManager.GetInstance().AddCoin(coin);
        StartCoroutine(BackToMenu());
    }

    private IEnumerator BackToMenu(){
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Menu");
    }

    protected IEnumerator SpawnWaves(){
        int level = MenuManager.GetInstance().level;
        int enemyIndex = (level + waveIndex) % enemys.Length;
        int levelRound = level / enemys.Length + 1;
        GameObject enemy = enemys[enemyIndex];
        enemyCount = baseEnemyNumber * levelRound;
        float enemyLife = baseEnemyLife * levelRound;

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnValue.x, spawnValue.x),
                spawnValue.y,
                spawnValue.z
            );
            Quaternion spawnQuaternion = Quaternion.identity;
            Instantiate(enemys[enemyIndex], spawnPosition, spawnQuaternion);
            enemys[enemyIndex].GetComponent<EnemyController>().setLife(enemyLife);
            yield return new WaitForSeconds(0.3f);
        }
        waveIndex++;
    }

    void Update()
    {
        if(waveKillCount == enemyCount){
            waveKillCount = 0;
            if(waveIndex == waves){
                GameOver();
                MenuManager.GetInstance().AddLevel();
            }else{
                StartCoroutine(SpawnWaves());
            }
        }
    }
}