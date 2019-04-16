using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListener : MonoBehaviour {
    Button[] buttons;

    private void Awake()
    {
    }

    // Use this for initialization
    void Start () {
        MenuManager.GetInstance().UpdateUI();
        buttons = transform.GetComponentsInChildren<Button>();
        foreach(Button button in buttons){
            button.onClick.AddListener(() => OnButtonClick(button.gameObject.transform.parent.gameObject.name));
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnButtonClick(string parentName){
        switch(parentName)
        {
            case "RateLayout":
                MenuManager.GetInstance().LvUpWeaponFireRate();
                break;
            case "PowerLayout":
                MenuManager.GetInstance().LvUpWeaponPower();
                break;
            case "StrenghtLayout":
                MenuManager.GetInstance().LvUpSubWeaponScope();
                break;
            case "SubPowerLayout":
                MenuManager.GetInstance().LvUpSubWeaponPower();
                break;
        }
    }

    public void GameStart(){
        MenuManager.GetInstance().GameStart();
    }

    public void GreenballSelected()
    {
        MenuManager.GetInstance().currentSubWeapon = MenuManager.SubWeapon.GreenBall;
        MenuManager.GetInstance().UpdateUI();
    }

    public void OrangeshellSelected()
    {
        MenuManager.GetInstance().currentSubWeapon = MenuManager.SubWeapon.OrangeShell;
        MenuManager.GetInstance().UpdateUI();
    }

    public void LightningSelected(){
        MenuManager.GetInstance().currentSubWeapon = MenuManager.SubWeapon.Lightning;
        MenuManager.GetInstance().UpdateUI();
    }
}
