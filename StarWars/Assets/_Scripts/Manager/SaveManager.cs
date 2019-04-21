using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

    private void Awake()
    {
        //coin
        GetData("coin", MenuManager.GetInstance().coin);
        //weaponRate
        GetData("weaponrate", MenuManager.GetInstance().weaponFireRate);
        //weaponPower
        GetData("weaponpower", MenuManager.GetInstance().weaponPower);
        //greenball scope
        GetData("greenballscope", MenuManager.GetInstance().greenBallScope);
        //greenball power
        GetData("greenballpower", MenuManager.GetInstance().greenBallPower);
        //orangeshell scope
        GetData("orangeshellscope", MenuManager.GetInstance().orangeShellScope);
        //orangeshell power
        GetData("orangeshellpower", MenuManager.GetInstance().orangeShellPower);
        //lightning scope
        GetData("lightningscope", MenuManager.GetInstance().lightningScope);
        //lightning power
        GetData("lightningpower", MenuManager.GetInstance().lightningPower);
    }

    public static void SaveData()
    {
        PlayerPrefs.SetFloat("coin", MenuManager.GetInstance().coin);
        PlayerPrefs.SetFloat("weaponrate", MenuManager.GetInstance().weaponFireRate);
        PlayerPrefs.SetFloat("weaponpower", MenuManager.GetInstance().weaponPower);
        PlayerPrefs.SetFloat("greenballscope", MenuManager.GetInstance().greenBallScope);
        PlayerPrefs.SetFloat("greenballpower", MenuManager.GetInstance().greenBallPower);
        PlayerPrefs.SetFloat("orangeshellscope", MenuManager.GetInstance().orangeShellScope);
        PlayerPrefs.SetFloat("orangeshellpower", MenuManager.GetInstance().orangeShellPower);
        PlayerPrefs.SetFloat("lightningscope", MenuManager.GetInstance().lightningScope);
        PlayerPrefs.SetFloat("lightningpower", MenuManager.GetInstance().lightningPower);
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
            case "weaponrate":
                MenuManager.GetInstance().weaponFireRate = data;
                break;
            case "weaponpower":
                MenuManager.GetInstance().weaponPower = data;
                break;
            case "greenballscope":
                MenuManager.GetInstance().greenBallScope = data;
                break;
            case "greenballpower":
                MenuManager.GetInstance().greenBallPower = data;
                break;
            case "orangeshellscope":
                MenuManager.GetInstance().orangeShellScope = data;
                break;
            case "orangeshellpower":
                MenuManager.GetInstance().orangeShellPower = data;
                break;
            case "lightningscope":
                MenuManager.GetInstance().lightningScope = data;
                break;
            case "lightningpower":
                MenuManager.GetInstance().lightningPower = data;
                break;
        }
    }
}
