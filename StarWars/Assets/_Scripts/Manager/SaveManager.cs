using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//todo add enum data type : coin, level, weaponrate....

public class SaveManager : MonoBehaviour {

    private void Awake()
    {
        //coin
        GetData("coin", MenuManager.GetInstance().Coin);
        GetData("level", MenuManager.GetInstance().Level);
        //weaponRate
        GetData("weaponrate", MenuManager.GetInstance().WeaponFireRate);
        //weaponPower
        GetData("weaponpower", MenuManager.GetInstance().WeaponPower);
        //greenball scope
        GetData("greenballscope", MenuManager.GetInstance().GreenBallScope);
        //greenball power
        GetData("greenballpower", MenuManager.GetInstance().GreenBallPower);
        //orangeshell scope
        GetData("orangeshellscope", MenuManager.GetInstance().OrangeShellScope);
        //orangeshell power
        GetData("orangeshellpower", MenuManager.GetInstance().OrangeShellPower);
        //lightning scope
        GetData("lightningscope", MenuManager.GetInstance().LightningScope);
        //lightning power
        GetData("lightningpower", MenuManager.GetInstance().LightningPower);
    }

    public static void SaveData()
    {
        PlayerPrefs.SetFloat("coin", MenuManager.GetInstance().Coin);
        PlayerPrefs.SetFloat("level", MenuManager.GetInstance().Level);
        PlayerPrefs.SetFloat("weaponrate", MenuManager.GetInstance().WeaponFireRate);
        PlayerPrefs.SetFloat("weaponpower", MenuManager.GetInstance().WeaponPower);
        PlayerPrefs.SetFloat("greenballscope", MenuManager.GetInstance().GreenBallScope);
        PlayerPrefs.SetFloat("greenballpower", MenuManager.GetInstance().GreenBallPower);
        PlayerPrefs.SetFloat("orangeshellscope", MenuManager.GetInstance().OrangeShellScope);
        PlayerPrefs.SetFloat("orangeshellpower", MenuManager.GetInstance().OrangeShellPower);
        PlayerPrefs.SetFloat("lightningscope", MenuManager.GetInstance().LightningScope);
        PlayerPrefs.SetFloat("lightningpower", MenuManager.GetInstance().LightningPower);
        PlayerPrefs.Save();
    }

    void GetData(string key, float value){
        if(!PlayerPrefs.HasKey(key)){
            PlayerPrefs.SetFloat(key, value);
            PlayerPrefs.Save();
            return;
        }
        float data = PlayerPrefs.GetFloat(key);
        switch(key){
            case "coin":
                MenuManager.GetInstance().AddCoin(data);
                break;
            case "level":
                MenuManager.GetInstance().Level = data;
                break;
            case "weaponrate":
                MenuManager.GetInstance().WeaponFireRate = data;
                break;
            case "weaponpower":
                MenuManager.GetInstance().WeaponPower = data;
                break;
            case "greenballscope":
                MenuManager.GetInstance().GreenBallScope = data;
                break;
            case "greenballpower":
                MenuManager.GetInstance().GreenBallPower = data;
                break;
            case "orangeshellscope":
                MenuManager.GetInstance().OrangeShellScope = data;
                break;
            case "orangeshellpower":
                MenuManager.GetInstance().OrangeShellPower = data;
                break;
            case "lightningscope":
                MenuManager.GetInstance().LightningScope = data;
                break;
            case "lightningpower":
                MenuManager.GetInstance().LightningPower = data;
                break;
        }
    }
}
