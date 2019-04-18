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
    int waveKillCount;
    int enemyCount;
    int level = 1;

    public Boundary boundary;
    public Vector3 spawnValue;

    private int coin;
    private bool gameOver;
    public Text coinText;
    public Text gameOverText;
    public Text restartText;

    GameObject enemyStonePrefab;
    GameObject enemyAsteroidPrefab;
    GameObject enemyMeteoritePrefab;
    GameObject enemyShipPrefab;

    private void Start()
    {
        enemyStonePrefab = (GameObject)Resources.Load("Stone");
        enemyAsteroidPrefab = (GameObject)Resources.Load("Asteroid");
        enemyMeteoritePrefab = (GameObject)Resources.Load("Meteorite");
        enemyShipPrefab = (GameObject)Resources.Load("EnemyShip");

        level = MenuManager.GetInstance().level;
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
        enemyCount = 4 + 3 + 2 + level * 3 + waveIndex * 3;
        yield return new WaitForSeconds(1f);

        //todo 生成4/3/2+level+wave个1/2/3级怪
        for (int i = 0; i < 4 + level + waveIndex; i ++){
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnValue.x, spawnValue.x),
                spawnValue.y,
                spawnValue.z
            );
            Quaternion spawnQuaternion = Quaternion.identity;
            GameObject enemy = Instantiate(enemyStonePrefab, spawnPosition, spawnQuaternion);
            enemy.GetComponent<EnemyController>().SetLife(5+level+ waveIndex);
            Vector3 scale = enemy.transform.localScale;
            enemy.transform.localScale = new Vector3(
                scale.x + level + waveIndex,
                scale.y,
                scale.z + level + waveIndex
            );
            yield return new WaitForSeconds(0.3f);
        }
        for (int i = 0; i < 3 + level + waveIndex; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnValue.x, spawnValue.x),
                spawnValue.y,
                spawnValue.z
            );
            Quaternion spawnQuaternion = Quaternion.identity;
            GameObject enemy = Instantiate(enemyMeteoritePrefab, spawnPosition, spawnQuaternion);
            enemy.GetComponent<EnemyController>().SetLife(7 + level + waveIndex);
            Vector3 scale = enemy.transform.localScale;
            enemy.transform.localScale = new Vector3(
                scale.x + level + waveIndex,
                scale.y,
                scale.z + level + waveIndex
            );
            yield return new WaitForSeconds(0.3f);
        }
        for (int i = 0; i < 2 + level + waveIndex; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnValue.x, spawnValue.x),
                spawnValue.y,
                spawnValue.z
            );
            Quaternion spawnQuaternion = Quaternion.identity;
            GameObject enemy = Instantiate(enemyShipPrefab, spawnPosition, spawnQuaternion);
            enemy.GetComponent<EnemyController>().SetLife(9 + level + waveIndex);
            Vector3 scale = enemy.transform.localScale;
            enemy.transform.localScale = new Vector3(
                scale.x + level + waveIndex,
                scale.y,
                scale.z + level + waveIndex
            );
            yield return new WaitForSeconds(0.3f);
        }
        //todo 1/2/3级怪设置生命5/7/9+level+wave,大小1/2/3+level+wave(无限趋近于max值，不然超过max太快也不好)
        //todo 1级怪现在样子，2级怪间隔时间回血，3级怪死后爆炸
        //todo 敌人路径随机角度
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