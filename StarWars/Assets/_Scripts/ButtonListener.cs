using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListener : MonoBehaviour {

    private void Awake()
    {
    }

    // Use this for initialization
    void Start () {
        MenuManager.GetInstance().UpdateUI();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameStart(){
        MenuManager.GetInstance().GameStart();
    }

    public void WeaponFireRateUp(){
        MenuManager.GetInstance().LvUpWeaponFireRate();
    }

    public void WeaponPowerUp(){
        MenuManager.GetInstance().LvUpWeaponPower();
    }
}
