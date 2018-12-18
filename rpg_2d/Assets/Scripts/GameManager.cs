using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Controller2D controller2D;
    public Texture playerHealthTexture;
    public float screenPositionX;
    public float screenPositionY;
    public int iconSizeX = 25;
    public int iconSizeY = 25;
    public int playerHealth = 3;
    GameObject player;

    public int curEXP = 0;
    int maxEXP = 50;
    int level = 1;
    bool playerStats;
    public Text statsDisplay;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    private void OnGUI()
    {
        for (int h = 0; h < playerHealth; h ++){
            GUI.DrawTexture(new Rect(screenPositionX + h * iconSizeX, screenPositionY, iconSizeX, iconSizeY), playerHealthTexture, ScaleMode.ScaleToFit, true, 0);
        }
    }

    // Update is called once per frame
    void Update () {
        if(curEXP >= maxEXP){
            LevelUp();
        }

        if(Input.GetKeyDown(KeyCode.C)){
            playerStats = !playerStats;
        }

        if(playerStats){
            statsDisplay.text = "level:" + level + "\nexp:" + curEXP + "/" + maxEXP;
        }else{
            statsDisplay.text = "";
        }

        if(Input.GetKeyDown(KeyCode.E)){
            curEXP += 10;
        }
	}

    void LevelUp(){
        curEXP = 0;
        maxEXP += 50;
        level++;
        playerHealth++;
    }

    void PlayerDamaged(int damage){
        if(player.GetComponent<Renderer>().enabled){
            playerHealth -= damage;
        }
        if(playerHealth <= 0){
            RestartScene();
        }
    }

    void RestartScene(){
        Application.LoadLevel(Application.loadedLevel);
    }
}
