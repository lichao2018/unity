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

    static MenuManager instance;

    float coin = 100;

    public float Coin
    {
        set{
            coin = value;
            SaveManager.SaveData();
        }
        get
        {
            return coin;
        }
    }

    float level = 1;

    public float Level
    {
        set{
            level = value;
            SaveManager.SaveData();
        }
        get
        {
            return level;
        }
    }

    float weaponFireRate = 1;

    public float WeaponFireRate
    {
        set{
            weaponFireRate = value;
            SaveManager.SaveData();
        }
        get
        {
            return weaponFireRate;
        }
    }

    float weaponPower = 1;

    public float WeaponPower
    {
        set
        {
            weaponPower = value;
            SaveManager.SaveData();
        }
        get
        {
            return weaponPower;
        }
    }

    float greenBallScope = 1;

    public float GreenBallScope
    {
        set
        {
            greenBallScope = value;
            SaveManager.SaveData();
        }
        get
        {
            return greenBallScope;
        }
    }

    float greenBallPower = 1;

    public float GreenBallPower
    {
        set
        {
            greenBallPower = value;
            SaveManager.SaveData();
        }
        get
        {
            return greenBallPower;
        }
    }

    float orangeShellScope = 1;

    public float OrangeShellScope
    {
        set
        {
            orangeShellScope = value;
            SaveManager.SaveData();
        }
        get
        {
            return orangeShellScope;
        }
    }

    float orangeShellPower = 1;

    public float OrangeShellPower
    {
        set
        {
            orangeShellPower = value;
            SaveManager.SaveData();
        }
        get
        {
            return orangeShellPower;
        }
    }

    float lightningScope = 1;

    public float LightningScope
    {
        set
        {
            lightningScope = value;
            SaveManager.SaveData();
        }
        get
        {
            return lightningScope;
        }
    }

    float lightningPower = 1;

    public float LightningPower
    {
        set
        {
            lightningPower = value;
            SaveManager.SaveData();
        }
        get
        {
            return lightningPower;
        }
    }

    public SubWeapon currentSubWeapon = SubWeapon.GreenBall;

    public static MenuManager GetInstance()
    {
        if (instance == null)
        {
            instance = new MenuManager();
        }
        return instance;
    }

    MenuManager()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            return;
        }
        Text coinText = GameObject.Find("CoinText").GetComponent<Text>();
        Text levelText = GameObject.Find("LevelText").GetComponent<Text>();
        GameObject root = GameObject.Find("TabPanel");
        Text weaponFireRateText = root.transform.Find("WeaponPanel/RateLayout/Text").gameObject.GetComponent<Text>();
        Text weaponPowerText = root.transform.Find("WeaponPanel/PowerLayout/Text").gameObject.GetComponent<Text>();
        Text subWeaponScopeLvUpText = root.transform.Find("SubPanel/StrenghtLayout/Text").gameObject.GetComponent<Text>();
        Text subWeaponPowerLvUpText = root.transform.Find("SubPanel/SubPowerLayout/Text").gameObject.GetComponent<Text>();

        coinText.text = "Coin:" + Coin;
        levelText.text = "Level : " + level;
        if (weaponFireRateText.enabled)
        {
            weaponFireRateText.text = "射速(Lv" + WeaponFireRate + ")";
        }
        if (weaponPowerText.enabled)
        {
            weaponPowerText.text = "火力(Lv" + WeaponPower + ")";
        }
        float subScope = 1;
        float subPower = 1;
        switch (currentSubWeapon)
        {
            case SubWeapon.GreenBall:
                subScope = GreenBallScope;
                subPower = GreenBallPower;
                break;
            case SubWeapon.OrangeShell:
                subScope = OrangeShellScope;
                subPower = OrangeShellPower;
                break;
            case SubWeapon.Lightning:
                subScope = LightningScope;
                subPower = LightningPower;
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

    public void AddCoin(float value)
    {
        Coin += value;
        UpdateUI();
    }

    public void AddLevel()
    {
        Level++;
    }

    public void SubCoin(int value)
    {
        if ((Coin - value) >= 0)
        {
            Coin -= value;
            UpdateUI();
        }
        else
        {
            Debug.Log("Coin lacking");
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }

    public void LvUpWeaponFireRate()
    {
        if (Coin >= 10)
        {
            WeaponFireRate++;
            SubCoin(10);
        }
    }

    public void LvUpWeaponPower()
    {
        if (Coin >= 10)
        {
            WeaponPower++;
            SubCoin(10);
        }
    }

    public void LvUpSubWeaponScope()
    {
        if (Coin >= 10)
        {
            switch (currentSubWeapon)
            {
                case SubWeapon.GreenBall:
                    GreenBallScope++;
                    break;
                case SubWeapon.OrangeShell:
                    OrangeShellScope++;
                    break;
                case SubWeapon.Lightning:
                    LightningScope++;
                    break;
            }
            SubCoin(10);
        }
    }

    public void LvUpSubWeaponPower()
    {
        if (Coin >= 10)
        {
            switch (currentSubWeapon)
            {
                case SubWeapon.GreenBall:
                    GreenBallPower++;
                    break;
                case SubWeapon.OrangeShell:
                    OrangeShellPower++;
                    break;
                case SubWeapon.Lightning:
                    LightningPower++;
                    break;
            }
            SubCoin(10);
        }
    }
}
