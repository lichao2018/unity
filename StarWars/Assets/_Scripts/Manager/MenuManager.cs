using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager
{
    public enum SubWeapon{
        GreenBall,
        OrangeShell,
        Lightning
    }

    float coin = 100;
    static MenuManager instance;

    public int level = 1;

    public float weaponFireRate = 1;
    public float weaponPower = 1;
    public float greenBallScope = 1;
    public float greenBallPower = 1;
    public float orangeShellScope = 1;
    public float orangeShellPower = 1;
    public float lightningScope = 1;
    public float lightningPower = 1;
    public SubWeapon currentSubWeapon = SubWeapon.Lightning;

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
        Text coinText = GameObject.Find("CoinText").GetComponent<Text>();
        Text levelText = GameObject.Find("LevelText").GetComponent<Text>();
        GameObject root = GameObject.Find("TabPanel");
        Text weaponFireRateText = root.transform.Find("WeaponPanel/RateLayout/Text").gameObject.GetComponent<Text>();
        Text weaponPowerText = root.transform.Find("WeaponPanel/PowerLayout/Text").gameObject.GetComponent<Text>();
        Text subWeaponScopeLvUpText = root.transform.Find("SubPanel/StrenghtLayout/Text").gameObject.GetComponent<Text>();
        Text subWeaponPowerLvUpText = root.transform.Find("SubPanel/SubPowerLayout/Text").gameObject.GetComponent<Text>();

        coinText.text = "Coin:" + coin;
        levelText.text = "Level : " + level;
        if (weaponFireRateText.enabled)
        {
            weaponFireRateText.text = "射速(Lv" + weaponFireRate + ")";
        }
        if (weaponPowerText.enabled)
        {
            weaponPowerText.text = "火力(Lv" + weaponPower + ")";
        }
        float subScope = 1;
        float subPower = 1;
        switch(currentSubWeapon){
            case SubWeapon.GreenBall:
                subScope = greenBallScope;
                subPower = greenBallPower;
                break;
            case SubWeapon.OrangeShell:
                subScope = orangeShellScope;
                subPower = orangeShellPower;
                break;
        }
        if (subWeaponScopeLvUpText.enabled)
        {
            subWeaponScopeLvUpText.text = "强度(Lv" + subScope + ")";
        }
        if (subWeaponPowerLvUpText.enabled)
        {
            subWeaponPowerLvUpText.text = "火力(Lv" + subPower + ")";
        }
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
            switch(currentSubWeapon){
                case SubWeapon.GreenBall:
                    greenBallScope++;
                    break;
                case SubWeapon.OrangeShell:
                    orangeShellScope++;
                    break;
            }
            SubCoin(10);
        }
    }

    public void LvUpSubWeaponPower()
    {
        if (coin >= 10)
        {
            switch (currentSubWeapon)
            {
                case SubWeapon.GreenBall:
                    greenBallPower++;
                    break;
                case SubWeapon.OrangeShell:
                    orangeShellPower++;
                    break;
            }
            SubCoin(10);
        }
    }
}
