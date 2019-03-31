using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager
{
    float coin = 100;
    static MenuManager instance;
    Text coinText;
    Text weaponFireRateText;
    Text weaponPowerText;

    public int level = 1;

    public float weaponFireRate = 1;
    public float weaponPower = 1;

    public static MenuManager GetInstance(){
        if(instance == null){
            instance = new MenuManager();
        }
        return instance;
    }

    MenuManager(){
        UpdateUI();
    }

    public void UpdateUI()
    {
        if(SceneManager.GetActiveScene().name != "Menu"){
            return;
        }
        coinText = GameObject.Find("CoinText").GetComponent<Text>();
        weaponFireRateText = GameObject.Find("ButtonWeaponFireRateLvUp").GetComponentInChildren<Text>();
        weaponPowerText = GameObject.Find("ButtonWeaponPowerLvUp").GetComponentInChildren<Text>();
        Text levelText = GameObject.Find("LevelText").GetComponent<Text>();

        coinText.text = "Coin:" + coin;
        weaponFireRateText.text = "WeaponFireRate - " + weaponFireRate;
        weaponPowerText.text = "WeaponPower - " + weaponPower;
        levelText.text = "Level : " + level;
    }

    public void AddCoin(int value)
    {
        coin += value;
        UpdateUI();
    }

    public void AddLevel(){
        level++;
    }

    public void SubCoin(int value){
        if((coin-value) >= 0){
            coin -= value;
            UpdateUI();
        }else{
            Debug.Log("Coin lacking");
        }
    }

    public void GameStart(){
        SceneManager.LoadScene("Game");
    }
    
    public void LvUpWeaponFireRate(){
        if(coin >= 10){
            weaponFireRate++;
            SubCoin(10);
        }
    }

    public void LvUpWeaponPower(){
        if (coin >= 10)
        {
            weaponPower++;
            SubCoin(10);
        }
    }
}
