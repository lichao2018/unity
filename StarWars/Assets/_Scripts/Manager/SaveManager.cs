using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//todo add enum data type : coin, level, weaponrate....

public class SaveManager : MonoBehaviour {

    public enum DataType{
        Coin,
        Level,
        WeaponRate,
        WeaponPower,
        GreenballScope,
        GreenballPower,
        OrangeshellScope,
        OrangeshellPower,
        LightningScope,
        LightningPower
    }

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

    public static void SaveData(DataType type)
    {
        switch(type){
            case DataType.Coin:
                PlayerPrefs.SetFloat("coin", MenuManager.GetInstance().Coin);
                break;
            case DataType.Level:
                PlayerPrefs.SetFloat("level", MenuManager.GetInstance().Level);
                break;
            case DataType.WeaponRate:
                PlayerPrefs.SetFloat("weaponrate", MenuManager.GetInstance().WeaponFireRate);
                break;
            case DataType.WeaponPower:
                PlayerPrefs.SetFloat("weaponpower", MenuManager.GetInstance().WeaponPower);
                break;
            case DataType.GreenballScope:
                PlayerPrefs.SetFloat("greenballscope", MenuManager.GetInstance().GreenBallScope);
                break;
            case DataType.GreenballPower:
                PlayerPrefs.SetFloat("greenballpower", MenuManager.GetInstance().GreenBallPower);
                break;
            case DataType.OrangeshellScope:
                PlayerPrefs.SetFloat("orangeshellscope", MenuManager.GetInstance().OrangeShellScope);
                break;
            case DataType.OrangeshellPower:
                PlayerPrefs.SetFloat("orangeshellpower", MenuManager.GetInstance().OrangeShellPower);
                break;
            case DataType.LightningScope:
                PlayerPrefs.SetFloat("lightningscope", MenuManager.GetInstance().LightningScope);
                break;
            case DataType.LightningPower:
                PlayerPrefs.SetFloat("lightningpower", MenuManager.GetInstance().LightningPower);
                break;
        }
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
