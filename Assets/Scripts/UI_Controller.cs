using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public GameObject wavePanel;
    public GameObject gameOver;
    public GameObject clear;
    public static int stage = 1;
    public static int maxStage = 3;
    public static int wave = 1;
    public static int maxWave = 3;
    public static int enemies = 0;
    public static int maxEnemies = 100;
    public static int attempt = 1;
    public static int maxAttempt = 2;
    public static bool attempting = false;
    public static bool isGameOver = false;
    public static bool isInstantiated = false;
    public static bool isUpgrade = false;
    public static int kills = 0;

    //stats
    public int pointRate = 5;
    public static int points = 0;
    public static float dragPower = 1f;
    public static float attackPower = 1f;
    //maxAttempt

    private int lastKillPoints = 0;

    void Update(){
        if (enemies > maxEnemies){
            isGameOver = true;
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }

        if (attempt > maxAttempt)
        {
            if (wave + 1 > maxWave)
            {
                isInstantiated = false;
                isUpgrade = true;
            }else{
                wave += 1;
                attempt = 1;
                isInstantiated = false;                    
            }
        }

        if (isUpgrade && !attempting){
            if (maxStage < stage+1){
                isGameOver = true;
                clear.SetActive(true);
                Time.timeScale = 0;
            }else{
                wavePanel.SetActive(true);
            }
        }

        // Increase points for every pointRate kills
        if (kills / pointRate > lastKillPoints)
        {
            points += 1;
            lastKillPoints = kills / pointRate;
        }
    }

    public void AddDragPower(){
        if (points >= 1){
            dragPower += 0.1f;
            points -= 1;
        }
    }

    public void AddAttackPower(){
        if (points >= 1){
            attackPower += 0.2f;
            points -= 1;
        }
    }

    public void AddMaxAttempt(){
        if (maxAttempt < 5 && points >= 10)
        {
            maxAttempt += 1;
            points -= 10;
        }
    }

    public async void UpgradeDone(){
        await Task.Delay(800); // 1초 지연
        stage += 1;
        wave = 1;
        attempt = 1;
        isUpgrade = false;
        wavePanel.SetActive(false);
    }
}
