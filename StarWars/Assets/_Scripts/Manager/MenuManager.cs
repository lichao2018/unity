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
    public float subWeaponScope = 1;
    public float subWeaponPower = 1;

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
        Text subWeaponScopeLvUpText = GameObject.Find("SubWeaponScopeLvUp").GetComponentInChildren<Text>();
        Text subWeaponPowerLvUpText = GameObject.Find("SubWeaponPowerLvUp").GetComponentInChildren<Text>();

        coinText.text = "Coin:" + coin;
        weaponFireRateText.text = "WeaponFireRate - " + weaponFireRate;
        weaponPowerText.text = "WeaponPower - " + weaponPower;
        levelText.text = "Level : " + level;
        subWeaponScopeLvUpText.text = "SubScope-" + subWeaponScope;
        subWeaponPowerLvUpText.text = "SubPower-" + subWeaponPower;
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

    public void LvUpSubWeaponScope()
    {
        if (coin >= 10)
        {
            subWeaponScope++;
            SubCoin(10);
        }
    }

    public void LvUpSubWeaponPower()
    {
        if (coin >= 10)
        {
            subWeaponPower++;
            SubCoin(10);
        }
    }
}
